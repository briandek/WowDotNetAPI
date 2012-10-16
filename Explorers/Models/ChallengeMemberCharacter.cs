using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    
    [DataContract]
    public class ChallengeMemberCharacter
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "realm")]
        public string Realm { get; set; }

        [DataMember(Name = "class")]
        private int @class { get; set; }

        [DataMember(Name = "race")]
        private int race { get; set; }

        [DataMember(Name = "gender")]
        private int gender { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "achievementPoints")]
        public int AchievementPoints { get; set; }

        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }

        [DataMember(Name = "guild")]
        public string Guild { get; set; }

        [DataMember(Name = "battlegroup")]
        public string Battlegroup { get; set; }

        
        public CharacterClass Class { get { return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), @class).Replace(' ', '_')); } }
        public CharacterRace @Race { get { return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), race).Replace(' ', '_')); } }
        public CharacterGender Gender { get { return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), gender).Replace(' ', '_')); } }

        //TODO: cleanup 
        //probably better to override equality operators http://msdn.microsoft.com/en-us/library/ms173147.aspx
        public int CompareTo(Character other)
        {
            if (Name == other.Name
                && Realm == other.Realm
                && Class == other.Class
                && Race == other.Race
                && Gender == other.Gender)
            {
                return 0;
            }

            return -1;
        }
    }
}
