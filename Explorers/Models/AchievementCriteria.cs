using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AchievementCriteria
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
