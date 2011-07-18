using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
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
        public int @Class { get; set; }
        
        [DataMember(Name = "race")]
        public int Race { get; set; }
        
        [DataMember(Name = "gender")]
        public int Gender { get; set; }
        
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
        public CharacterInventory Items { get; set; }
        
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
    }
}
