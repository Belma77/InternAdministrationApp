﻿using System.Text.Json.Serialization;

namespace Backend.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum UserRole
    {
        ADMIN,
        EDITOR
    }
}