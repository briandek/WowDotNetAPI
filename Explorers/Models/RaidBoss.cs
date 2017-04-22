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

        [DataMember(Name = "lfrKills")]
        public int LfrKills { get; set; }

        [DataMember(Name = "lfrTimestamp")]
        public ulong LfrTimestamp { get; set; }

        [DataMember(Name = "normalKills")]
        public int NormalKills { get; set; }

        [DataMember(Name = "normalTimestamp")]
        public ulong NormalTimestamp { get; set; }

        [DataMember(Name = "heroicKills")]
        public int HeroicKills { get; set; }

        [DataMember(Name = "heroicTimestamp")]
        public ulong HeroicTimestamp { get; set; }

        [DataMember(Name = "mythicKills")]
        public int MythicKills { get; set; }

        [DataMember(Name = "mythicTimestamp")]
        public ulong MythicrTimestamp { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
	}
}
