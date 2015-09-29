using FaghelgWebBackend.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Event
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "event_type")]
        public EventType eventType { get; set; }
        [JsonProperty(PropertyName = "event_id")]
        public string eventId { get; set; }
        [JsonProperty(PropertyName = "event_endpoint")]
        public string eventEndpoint {get; set;}

    }
}