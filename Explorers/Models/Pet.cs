using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Pet
    {
        [DataMember(Name = "battlePetId")]
        public int BattlePetId { get; set; }

        [DataMember(Name = "canBattle")]
        public bool CanBattle { get; set; }

        [DataMember(Name = "creatureId")]
        public long CreatureId { get; set; }

        [DataMember(Name = "creatureName")]
        public string CreatureName { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "isFavorite")]
        public bool IsFavorite { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "qualityId")]
        public int QualityId { get; set; }

        [DataMember(Name = "spellId")]
        public long SpellId { get; set; }

        [DataMember(Name = "stats")]
        public PetStats Stats { get; set; }

    }
}
