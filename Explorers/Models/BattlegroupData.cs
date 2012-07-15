using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class BattlegroupData
    {
        [DataMember(Name = "battlegroups")]
        public IEnumerable<BattlegroupInfo> Battlegroups { get; set; }
    }
}
