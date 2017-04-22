using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class CharacterItem
	{
        [DataMember(Name="id")]
		public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "quality")]
        public int Quality { get; set; }

		[DataMember(Name = "itemLevel")]
		public int ItemLevel { get; set; }

        [DataMember(Name = "tooltipParams")]
        public ItemTooltipParameters TooltipParams { get; set; }

		[DataMember(Name = "stats")]
		public IEnumerable<ItemStat> Stats { get; set; }

		[DataMember(Name = "armor")]
		public int Armor { get; set; }

		[DataMember(Name = "context")]
		public string Context { get; set; }

		[DataMember(Name = "bonusLists")]
		public IEnumerable<int> BonusLists { get; set; }

		// Legion
		[DataMember(Name = "artifactId")]
		public int ArtifactId { get; set; }

		[DataMember(Name = "artifactTraits")]
		public IEnumerable<CharacterItemArtifactTrait> ArtifactTraits { get; set; }

		[DataMember(Name = "relics")]
		public IEnumerable<CharacterItemRelic> Relics { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
