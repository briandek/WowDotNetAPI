using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterStatistics
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "subCategories")]
        public IEnumerable<CharacterStatisticsSubcategory> SubCategories { get; set; }
    }
}