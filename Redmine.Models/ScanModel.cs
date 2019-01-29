using System.Runtime.Serialization;

namespace Redmine.Models
{
    [DataContract]
    public class ScanModel
    {
        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public string Key { get; set; }
    }
}
