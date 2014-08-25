using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class ItemTooltipParameters 
	{
        [DataMember(Name="gem0")]
        public int Gem0 { get; set; }
        
        [DataMember(Name = "gem1")]
        public int Gem1 { get; set; }
        
        [DataMember(Name = "gem2")]
        public int Gem2 { get; set; }

        [DataMember(Name = "enchant")]
        public int Enchant { get; set; }

        [DataMember(Name = "reforge")]
        public int Reforge { get; set; }

        [DataMember(Name = "set")]
        public IEnumerable<int> @Set { get; set; }

        [DataMember(Name = "seed")]
        public long Seed { get; set; }

        [DataMember(Name = "extraSocket")]
        public bool ExtraSocket { get; set; }

        [DataMember(Name = "suffix")]
        public int Suffix { get; set; }

        [DataMember(Name = "upgrade")]
		public ItemUpgrade ItemUpgrade { get; set; }
	}
}
