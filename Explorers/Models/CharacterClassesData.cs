using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterClassesData
    {
        [DataMember(Name = "classes")]
        public IEnumerable<CharacterClassInfo> Classes { get; set; }
    }
}
