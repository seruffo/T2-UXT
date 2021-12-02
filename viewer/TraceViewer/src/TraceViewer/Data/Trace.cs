#region Usings
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
#endregion

namespace TraceViewer.Data
{
    [DataContract]
    public class Trace
    {
        [JsonProperty("type")]
        public String type { get; set; }
        [JsonProperty("image")]
        public String image { get; set; }
        [JsonProperty("class")]
        public String Class { get; set; }
        [JsonProperty("Id")]
        public String Id { get; set; }
        [JsonProperty("mouseClass")]
        public string MouseClass { get; set; }
        [JsonProperty("MouseId")]
        public string MouseId { get; set; }
        [JsonProperty("X")]
        public string X { get; set; }
        [JsonProperty("Y")]
        public string Y { get; set; }
        [JsonProperty("keys")]
        public string keys { get; set; }
        [JsonProperty("scroll")]
        public string scroll { get; set; }
        [JsonProperty("height")]
        public string height { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("time")]
        public string time { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
    }
}
