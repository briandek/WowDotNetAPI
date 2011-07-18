using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class RaidBoss
	{
        [DataMember(Name="name")]
		public string Name { get; set; }

        [DataMember(Name = "normalKills")]
        public int NormalKills { get; set; }

        [DataMember(Name = "heroicKills")]
        public int HeroicKills { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
	}
}
