using System.Runtime.Serialization;

namespace WowDotNetAPI.Models {
    [DataContract]
	public class CharacterItemArtifactTrait {
        [DataMember(Name="id")]
		public int Id { get; set; }

        [DataMember(Name = "rank")]
        public int Rank { get; set; }
	}
}
