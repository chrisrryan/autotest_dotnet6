﻿using System.Text.Json.Serialization;

namespace autotest.Models
{
    public class Comment
    {
        [JsonPropertyName("postId")]
        public int PostId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}