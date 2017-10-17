using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApiApplication1.Models
{
    public class UserModel
    {
        [JsonProperty("no")]
        public int No { get; set; }

        [JsonProperty("id")]
        [Required]
        public string Id { get; set; }

        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}