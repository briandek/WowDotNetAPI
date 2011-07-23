using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterPet
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name = "creature")]
        public long Creature { get; set; }
        [DataMember(Name = "slot")]
        public int Slot { get; set; }
    }
}
