using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemGemBonusInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "srcItemId")]
        public int SourceItemId { get; set; }

        [DataMember(Name = "requiredSkillId")]
        public int RequiredSkillId { get; set; }

        [DataMember(Name = "requiredSkillRank")]
        public int RequiredSkillRank { get; set; }

        [DataMember(Name = "minLevel")]
        public int MinLevel { get; set; }

        [DataMember(Name = "itemLevel")]
        public int ItemLevel { get; set; }
    }
}
