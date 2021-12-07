using Newtonsoft.Json;

namespace ApiAutomation.Json_Model
{
    public class ToDosJsonModel : BaseTitleJsonModel
    {
        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
