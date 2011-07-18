using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterTalentTree
    {
        [DataMember(Name="points")]
        public string Points { get; set; }

        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
}
