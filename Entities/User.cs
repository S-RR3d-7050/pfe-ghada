namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string CIN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public string Username { get; set; }
    public bool IsActive { get; set; }


    [JsonIgnore]
    public string PasswordHash { get; set; }
}