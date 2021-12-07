using Newtonsoft.Json;

namespace ApiAutomation.Json_Model
{
    /// <summary>
    ///     Base json model for most of the json models.
    /// </summary>
    public abstract class BaseTitleJsonModel
    {
        /// <summary>
        ///     Gets or sets the user id property.
        /// </summary>
        [JsonProperty("userId")]
        public int UserId { get; set; }

        /// <summary>
        ///     Gets or sets the id property.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the title property.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
