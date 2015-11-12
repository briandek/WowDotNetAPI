using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PetList
    {
        [DataMember(Name = "pets")]
        public IEnumerable<Pet> Pets { get; set; }
    }
}
