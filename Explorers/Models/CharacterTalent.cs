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

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "build")]
        public string Build { get; set; }

        [DataMember(Name = "trees")]
        public IEnumerable<CharacterTalentTree> Trees { get; set; }

        [DataMember(Name = "glyphs")]
        public CharacterTalentGlyphs Glyphs { get; set; }
    }
}
