using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterMount
    {
        [DataMember(Name = "creatureId")]
        public int Id { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "isAquatic")]
        public bool IsAquatic { get; set; }

        [DataMember(Name = "isFlying")]
        public bool IsFlying { get; set; }

        [DataMember(Name = "isGround")]
        public bool IsGround { get; set; }

        [DataMember(Name = "isJumping")]
        public bool IsJumping { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "qualityId")]
        public int QualityId { get; set; }

        [DataMember(Name = "spellId")]
        public int SpellId { get; set; }
    }
}
