using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemGemInfo
    {
        [DataMember(Name = "bonus")]
        public ItemGemBonusInfo Bonus { get; set; }

        [DataMember(Name = "type")]
        public ItemGemType Type { get; set; }
    }
}
