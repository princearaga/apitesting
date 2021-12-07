using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAutomation.Json_Model
{
    public class PostJsonModel : BaseTitleJsonModel
    {
        [JsonProperty("body")]
        public string Body{ get; set; }
    }
}
