using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterStatisticsSubcategory
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "statistics")]
        public IEnumerable<CharacterStatisticEntry> StatisticEntries { get; set; }

        [DataMember(Name = "subCategories")]
        public IEnumerable<CharacterStatisticsSubcategory> SubCategories { get; set; }
    }
}
