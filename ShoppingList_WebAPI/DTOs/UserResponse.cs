namespace ShoppingList_WebAPI.DTOs;

public class UserResponse
{
    public int Id { get; set; }
    public string Name  { get; set; }
    public string Email { get; set; }
    
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}