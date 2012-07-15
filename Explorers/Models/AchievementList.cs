using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class AchievementList
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "achievements")]
        public IEnumerable<AchievementInfo> Achievements { get; set; }

        [DataMember(Name = "categories")]
        public IEnumerable<AchievementCategory> Categories { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
