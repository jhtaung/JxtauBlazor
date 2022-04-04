using Newtonsoft.Json;

namespace JxtauBlazor.Shared.Models
{
    public class EformUsers
    {
        public List<Value>? value { get; set; }

        [JsonProperty("@nextLink")]
        public string? NextLink { get; set; }
    }

    public class Value
    {
        public string id { get; set; } = "";
        public string username { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public bool disabled { get; set; }
    }
}
