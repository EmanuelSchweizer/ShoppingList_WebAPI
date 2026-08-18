# ---------- Build stage ----------
# Full SDK image — contains the compiler, only used to build.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the project file first and restore separately.
# Docker caches this layer, so NuGet only re-downloads when
# dependencies change — not on every source edit.
COPY ["ShoppingList_WebAPI/ShoppingList_WebAPI.csproj", "ShoppingList_WebAPI/"]
RUN dotnet restore "ShoppingList_WebAPI/ShoppingList_WebAPI.csproj"

# Now copy the rest of the source and compile.
COPY . .
WORKDIR /src/ShoppingList_WebAPI
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---------- Runtime stage ----------
# Runtime-only image (~110 MB vs ~800 MB for the SDK).
# The compiler is not shipped to production.
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# Copy only the build output from the previous stage.
COPY --from=build /app/publish .

# Documentation only — Railway routes via the PORT env variable.
EXPOSE 8080

ENTRYPOINT ["dotnet", "ShoppingList_WebAPI.dll"]