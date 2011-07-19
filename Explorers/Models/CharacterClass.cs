using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterClass
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "mask")]
        public int Mask { get; set; }

        [DataMember(Name = "powerType")]
        public string PowerType { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
