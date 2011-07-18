using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Models
{
    public class CharacterInventory
    {
        public int averageItemLevel { get; set; }
        public int averageItemLevelEquipped { get; set; }
        public CharacterItem head { get; set; }
        public CharacterItem neck { get; set; }
        public CharacterItem shoulder { get; set; }
        public CharacterItem back { get; set; }
        public CharacterItem chest { get; set; }
        public CharacterItem shirt { get; set; }
        public CharacterItem wrist { get; set; }
        public CharacterItem hands { get; set; }
        public CharacterItem waist { get; set; }
        public CharacterItem legs { get; set; }
        public CharacterItem feet { get; set; }
        public CharacterItem finger1 { get; set; }
        public CharacterItem finger2 { get; set; }
        public CharacterItem trinket1 { get; set; }
        public CharacterItem trinket2 { get; set; }
        public CharacterItem mainHand { get; set; }
        public CharacterItem offHand { get; set; }
        public CharacterItem ranged { get; set; }
    }
}
