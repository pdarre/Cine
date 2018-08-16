using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cine.Models
{
    public class Crew
    {
        [JsonProperty("cast_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CastId { get; set; }

        [JsonProperty("character", NullValueHandling = NullValueHandling.Ignore)]
        public string Character { get; set; }

        [JsonProperty("credit_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreditId { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gender { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public long? Order { get; set; }

        [JsonProperty("profile_path", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePath { get; set; }
    }
}