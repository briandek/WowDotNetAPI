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
        PALADIN = 2,
        HUNTER = 3,
        ROGUE = 4,
        PRIEST = 5,
        DEATH_KNIGHT = 6,
        SHAMAN = 7,
        MAGE = 8,
        WARLOCK = 9,
        MONK = 10,
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
        DRAENEI = 11,
        WORGEN = 22,
        PANDAREN_NEUTRAL = 24,
        PANDAREN_ALLIANCE = 25,
        PANDAREN_HORDE = 26
    }

    [DataContract]
    public enum CharacterGender
    {
        MALE = 0,
        FEMALE = 1,
    }

    [DataContract]
    public class Character : IComparable<Character>
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

        [DataMember(Name = "calcClass")]
        public char CalcClass { get; set; }

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

        [DataMember(Name = "achievements")]
        public Achievements Achievements { get; set; }

        [DataMember(Name = "appearance")]
        public CharacterAppearance Appearance { get; set; }

        [DataMember(Name = "mounts")]
        public CharacterMounts Mounts { get; set; }

        [DataMember(Name = "hunterPets")]
        public IEnumerable<CharacterHunterPet> HunterPets { get; set; }

        [DataMember(Name = "pets")]
        public CharacterPets Pets { get; set; }

        [DataMember(Name = "petSlots")]
        public IEnumerable<CharacterPetSlot> PetSlots { get; set; }

        [DataMember(Name = "progression")]
        public Progression Progression { get; set; }

        [DataMember(Name = "feed")]
        public IEnumerable<CharacterFeed> Feed { get; set; }

        [DataMember(Name = "pvp")]
        public CharacterPvP PvP { get; set; }

        [DataMember(Name = "quests")]
        public IEnumerable<int> Quests { get; set; }

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
