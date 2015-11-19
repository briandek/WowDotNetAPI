using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterEquipment
    {
        [DataMember(Name="averageItemLevel")]
        public int AverageItemLevel { get; set; }

        [DataMember(Name = "averageItemLevelEquipped")]
        public int AverageItemLevelEquipped { get; set; }

        [DataMember(Name = "head")]
        public CharacterItem Head { get; set; }

        [DataMember(Name = "neck")]
        public CharacterItem Neck { get; set; }

        [DataMember(Name = "shoulder")]
        public CharacterItem Shoulder { get; set; }

        [DataMember(Name = "back")]
        public CharacterItem Back { get; set; }

        [DataMember(Name = "chest")]
        public CharacterItem Chest { get; set; }

        [DataMember(Name = "shirt")]
        public CharacterItem Shirt { get; set; }

        [DataMember(Name = "tabard")]
        public CharacterItem Tabard { get; set; }

        [DataMember(Name = "wrist")]
        public CharacterItem Wrist { get; set; }

        [DataMember(Name = "hands")]
        public CharacterItem Hands { get; set; }

        [DataMember(Name = "waist")]
        public CharacterItem Waist { get; set; }

        [DataMember(Name = "legs")]
        public CharacterItem Legs { get; set; }

        [DataMember(Name = "feet")]
        public CharacterItem Feet { get; set; }

        [DataMember(Name = "finger1")]
        public CharacterItem Finger1 { get; set; }

        [DataMember(Name = "finger2")]
        public CharacterItem Finger2 { get; set; }

        [DataMember(Name = "trinket1")]
        public CharacterItem Trinket1 { get; set; }

        [DataMember(Name = "trinket2")]
        public CharacterItem Trinket2 { get; set; }

        [DataMember(Name = "mainHand")]
        public CharacterItem MainHand { get; set; }

        [DataMember(Name = "offHand")]
        public CharacterItem OffHand { get; set; }

        [DataMember(Name = "ranged")]
        public CharacterItem Ranged { get; set; }
    }
}
