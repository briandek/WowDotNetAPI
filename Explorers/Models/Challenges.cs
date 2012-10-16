using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Challenges
    {
        [DataMember(Name = "challenge")]
        public IEnumerable<Challenge> Challenge { get; set; }
    }
}
