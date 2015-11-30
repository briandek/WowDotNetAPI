using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PetType
    {
        [DataMember(Name = "id")]
        public int PetTypeId { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "typeAbilityId")]
        public int TypeAbilityId { get; set; }

        [DataMember(Name = "strongAgainstId")]
        public int StrongAgainstId { get; set; }

        [DataMember(Name = "weakAgainstId")]
        public int WeakAgainstId { get; set; }
    }
}
