using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Battlegroup
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string SLUG { get; set; }
    }
}
