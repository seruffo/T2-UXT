#region Usings
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System;
using System.Runtime.Serialization;
#endregion

namespace Firjan.Integracao.Dynamics.Application.ViewModels
{
    [DataContract]
    public class TraceViewModel : Base
    {
        [DataMember]
        public String type { get; set; }
        [DataMember]
        public String image { get; set; }
        [DataMember]
        public String Class { get; set; }
        [DataMember]
        public String Id { get; set; }
        [DataMember]
        public string MouseClass { get; set; }
        [DataMember]
        public string MouseId { get; set; }
        [DataMember]
        public string X { get; set; }
        [DataMember]
        public string Y { get; set; }
        [DataMember]
        public string keys { get; set; }
        [DataMember]
        public string scroll { get; set; }
        [DataMember]
        public string height { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public string date { get; set; }
    }
}
