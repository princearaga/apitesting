using Newtonsoft.Json;

namespace ApiAutomation.Json_Model
{
    public class CommentJsonModel
    {
        /// <summary>
        ///     Gets or sets the post id property.
        /// </summary>
        [JsonProperty("postId")]
        public int PostId { get; set; }

        /// <summary>
        ///     Gets or sets the id property.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name property.
        /// </summary>
        [JsonProperty("name")]
        public string Title { get; set; }


        /// <summary>
        ///     Gets or sets the email property.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the body property.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
