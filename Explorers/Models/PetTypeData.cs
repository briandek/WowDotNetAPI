using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PetTypeData
    {
        [DataMember(Name = "petTypes")]
        public IEnumerable<PetType> PetTypes { get; set; } 
    }
}
