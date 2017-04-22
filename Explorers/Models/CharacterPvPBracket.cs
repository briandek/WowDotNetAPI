using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterPvPBracket
    {
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        [DataMember(Name = "weeklyPlayed")]
        public int WeeklyPlayed { get; set; }

        [DataMember(Name = "weeklyWon")]
        public int WeeklyWon { get; set; }

        [DataMember(Name = "weeklyLost")]
        public int WeeklyLost { get; set; }

        [DataMember(Name = "seasonPlayed")]
        public int SeasonPlayed { get; set; }

        [DataMember(Name = "seasonWon")]
        public int SeasonWon { get; set; }

        [DataMember(Name = "seasonLost")]
        public int SeasonLost { get; set; }
    }
}
