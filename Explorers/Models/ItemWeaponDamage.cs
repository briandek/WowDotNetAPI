using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemWeaponDamage
    {
        [DataMember(Name="min")]
        public int MinDamage { get; set; }

        [DataMember(Name = "max")]
        public int MaxDamage { get; set; }
        
    }
}
