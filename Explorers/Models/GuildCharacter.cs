using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildCharacter
    {
        [DataMember(Name="lastModified")]
        public string LastModified { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "realm")]
        public string Realm { get; set; }

        [DataMember(Name = "guildRealm")]
		public string GuildRealm { get; set; }

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

        [DataMember(Name = "spec", IsRequired = false)]
        public GuildCharacterSpec Specialization { get; set; }

        public CharacterClass @Class { get { return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), @class).Replace(' ', '_')); } }
        public CharacterRace @Race { get { return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), race).Replace(' ', '_')); } }
        public CharacterGender Gender { get { return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), gender).Replace(' ', '_')); } }

    }
}
