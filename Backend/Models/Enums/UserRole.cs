using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Backend.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum UserRoleEnum
    {
        ADMIN,
        EDITOR
    }
}
