using Newtonsoft.Json;

namespace MonarchsProject.Models
{
    public class Monarch
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("nm")] public string Name { get; set; }

        [JsonProperty("cty")] public string City { get; set; }

        [JsonProperty("hse")] public string House { get; set; }

        [JsonProperty("yrs")] public string Years { get; set; }
    }
}