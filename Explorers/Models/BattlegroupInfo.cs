using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class BattlegroupInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }
    }
}
