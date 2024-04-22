namespace WebApi.Models.Users;
using WebApi.Entities;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public string CIN { get; set; }
    public string Token { get; set; }
}