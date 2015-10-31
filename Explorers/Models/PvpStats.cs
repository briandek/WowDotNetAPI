using System;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PvpStats
    {
        [DataMember(Name = "ranking")]
        public int Ranking { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "realmId")]
        public int RealmId { get; set; }

        [DataMember(Name = "realmName")]
        public string RealmName { get; set; }

        [DataMember(Name = "realmSlug")]
        public string RealmSlug { get; set; }

        [DataMember(Name = "raceId")]
        private int raceId { get; set; }

        [DataMember(Name = "classId")]
        private int classId { get; set; }

        [DataMember(Name = "specId")]
        private int specId { get; set; }

        [DataMember(Name = "factionId")]
        public int FactionId { get; set; }

        [DataMember(Name = "genderId")]
        private int genderId { get; set; }

        [DataMember(Name = "seasonWins")]
        public int SeasonWins { get; set; }

        [DataMember(Name = "seasonLosses")]
        public int SeasonLosses { get; set; }

        [DataMember(Name = "weeklyWins")]
        public int WeeklyWins { get; set; }

        [DataMember(Name = "weeklyLosses")]
        public int WeeklyLosses { get; set; }

        public CharacterClass Class { get { return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), classId).Replace(' ', '_')); } }
        public CharacterRace Race { get { return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), raceId).Replace(' ', '_')); } }
        public CharacterGender Gender { get { return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), genderId).Replace(' ', '_')); } }
        public CharacterSpec Spec { get { return (CharacterSpec)Enum.Parse(typeof(CharacterSpec), Enum.GetName(typeof(CharacterSpec), specId).Replace(' ', '_')); } }
    }
}
