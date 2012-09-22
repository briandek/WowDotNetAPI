using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterTalent
    {
        [DataMember(Name = "selected")]
        public bool Selected { get; set; }

        [DataMember(Name = "talents")]
        public IEnumerable<CharacterTalentInfo> Talents { get; set; }

        [DataMember(Name = "glyphs")]
        public CharacterTalentGlyphs Glyphs { get; set; }

        [DataMember(Name = "spec")]
        public CharacterTalentSpec Spec { get; set; }

        [DataMember(Name = "calcTalent")]
        public string CalcTalent { get; set; }

        [DataMember(Name = "calcSpec")]
        public string CalcSpec { get; set; }

        [DataMember(Name = "calcGlyph")]
        public string CalcGlyph { get; set; }
    }
}
