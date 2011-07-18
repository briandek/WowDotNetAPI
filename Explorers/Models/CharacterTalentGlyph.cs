using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterTalentGlyph
    {
        [DataMember(Name="glyph")]
        public int Glyph { get; set; }

        [DataMember(Name = "item")]
        public int Item { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }
    }
}
