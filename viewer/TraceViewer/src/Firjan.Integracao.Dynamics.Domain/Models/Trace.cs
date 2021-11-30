using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firjan.Integracao.Dynamics.Domain.Models
{
    [Table("trace")]
    public class Trace
    {
        [System.ComponentModel.DataAnnotations.Key]
        public String type { get; set; }
        public String image { get; set; }
        public String Class { get; set; }
        public String Id { get; set; }
        public string MouseClass { get; set; }
        public string MouseId { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string keys { get; set; }
        public string scroll { get; set; }
        public string height { get; set; }
        public string url { get; set; }
        public string time { get; set; }
        public string date { get; set; }
    }
}
