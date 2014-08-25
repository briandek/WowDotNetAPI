using System.Runtime.Serialization;

namespace WowDotNetAPI.Models {
	[DataContract]
	public class ItemUpgrade {
		[DataMember(Name = "current")]
		public int Current { get; set; }

		[DataMember(Name = "total")]
		public int Total { get; set; }

		[DataMember(Name = "itemLevelIncrement")]
		public int ItemLevelIncrement { get; set; }

	}
}
