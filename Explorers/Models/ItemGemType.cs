using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemGemType
    {
        [DataMember(Name = "type")]
        public string Color { get; set; }
    }
}
