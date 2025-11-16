using System.Text.Json.Serialization;

namespace Task.Shared.DTOs.Comman
{
    public abstract class BaseDto //برای جلوگیری از نمونه سازی
    {
        [JsonPropertyOrder(-1)]
        public int Id { get; set; }
    }
}
