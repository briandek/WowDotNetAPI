using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum CharacterClass
    {
        WARRIOR = 1,
        HUNTER = 2,
        PALADIN = 3,
        ROGUE = 4,
        PRIEST = 5,
        DEATH_KNIGHT = 6,
        SHAMAN = 7,
        MAGE = 8,
        WARLOCK = 9,
        DRUID = 11
    }

    [DataContract]
    public enum CharacterRace
    {
        HUMAN = 1,
        ORC = 2,
        DWARF = 3,
        NIGHT_ELF = 4,
        UNDEAD = 5,
        TAUREN = 6,
        GNOME = 7,
        TROLL = 8,
        GOBLIN = 9,
        BLOOD_ELF = 10,
        DRAENIE = 11,
        WORGEN = 22
    }

    [DataContract]
    public enum CharacterGender
    {
        MALE = 0,
        FEMALE = 1,
    }

    [DataContract]
    public class Character
    {
        [DataMember(Name = "lastModified")]
        public string LastModified { get; set; }

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
        public CharacterGuild Guild { get; set; }

        [DataMember(Name = "stats")]
        public CharacterStats Stats { get; set; }

        [DataMember(Name = "talents")]
        public IEnumerable<CharacterTalent> Talents { get; set; }

        [DataMember(Name = "items")]
        public CharacterEquipment Items { get; set; }

        [DataMember(Name = "reputation")]
        public IEnumerable<CharacterReputation> Reputation { get; set; }

        [DataMember(Name = "titles")]
        public IEnumerable<CharacterTitle> Titles { get; set; }

        [DataMember(Name = "professions")]
        public CharacterProfessions Professions { get; set; }

        [DataMember(Name = "appearance")]
        public CharacterAppearance Appearance { get; set; }

        [DataMember(Name = "companions")]
        public IEnumerable<int> Companions { get; set; }

        [DataMember(Name = "mounts")]
        public IEnumerable<int> Mounts { get; set; }

        [DataMember(Name = "progression")]
        public Progression Progression { get; set; }

        public CharacterClass @Class { get { return (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), @class).Replace(' ', '_')); } }
        public CharacterRace @Race { get { return (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), race).Replace(' ', '_')); } }
        public CharacterGender Gender { get { return (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), gender).Replace(' ', '_')); } }

    }
}
