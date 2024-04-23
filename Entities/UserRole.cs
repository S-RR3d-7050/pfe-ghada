using System.Text.Json.Serialization;

namespace WebApi.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole
{
    Admin,
    Médecin,
    Réceptionniste
}
