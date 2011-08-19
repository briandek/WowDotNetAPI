using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemBonusStat
    {
        [DataMember(Name = "stat")]
        public int Stat { get; set; }

        [DataMember(Name = "amount")]
        public int Amount { get; set; }

        [DataMember(Name = "reforged")]
        public bool Reforged { get; set; }
    }
}
