using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models {
    [DataContract]
	public class CharacterItemRelic {
        [DataMember(Name="socket")]
		public int Socket { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }

        [DataMember(Name = "context")]
        public int Context { get; set; }

		[DataMember(Name = "bonusLists")]
		public IEnumerable<int> BonusLists { get; set; }
	}
}
