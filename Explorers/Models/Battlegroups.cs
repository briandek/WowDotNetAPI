using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Battlegroups
    {
        [DataMember(Name = "battlegroups")]
        public IEnumerable<Battlegroup> battlegroups { get; set; }
    }
}
