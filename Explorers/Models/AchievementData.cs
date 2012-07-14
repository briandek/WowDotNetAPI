using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    public class AchievementData
    {
        [DataMember(Name = "achievements")]
        public IEnumerable<AchievementList> Lists { get; set; }
    }
}
