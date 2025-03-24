using System.Text.Json.Serialization;

namespace ToDoApi.Entity.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
}
