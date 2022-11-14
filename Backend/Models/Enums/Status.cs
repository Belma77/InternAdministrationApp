using System.Text.Json.Serialization;

namespace Backend.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum StatusEnum
    {
        Applied, 
        Preselection,
        Inselection,
        Completed,
        Rejected
    }
}
