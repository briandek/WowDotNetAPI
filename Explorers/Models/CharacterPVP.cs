using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterPvP
    {
        [DataMember(Name = "brackets")]
        public CharacterPvPBrackets Brackets { get; set; }
    }
}
