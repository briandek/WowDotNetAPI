using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Mounts
    {
        [DataMember(Name = "mounts")]
        public IEnumerable<Mount> MountList { get; set; } 
    }
}
