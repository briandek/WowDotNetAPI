using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ChallengeMap
    {
        [DataMember(Name = "goldCriteria")]
        public ChallengeTime GoldCriteria { get; set; }

        [DataMember(Name = "silverCriteria")]
        public ChallengeTime SilverCriteria { get; set; }

        [DataMember(Name = "bronzeCriteria")]
        public ChallengeTime BronzeCriteria { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "hasChallengeMode")]
        public bool HasChallengeMode { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }
    }
}
