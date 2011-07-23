using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Achievements
    {
        [DataMember(Name = "achievementsCompleted")]
        public IEnumerable<int> AchievementsCompleted { get; set; }
        
        [DataMember(Name = "achievementsCompletedTimestamp")]
        public IEnumerable<long> AchievementsCompletedTimestamp { get; set; }
        
        [DataMember(Name = "criteria")]
        public IEnumerable<int> Criteria { get; set; }
        
        [DataMember(Name = "criteriaQuantity")]
        public IEnumerable<long> CriteriaQuantity { get; set; }
        
        [DataMember(Name = "criteriaTimestamp")]
        public IEnumerable<long> CriteriaTimestamp { get; set; }

        [DataMember(Name = "criteriaCreated")]
        public IEnumerable<long> CriteriaCreated { get; set; }
    }
}
