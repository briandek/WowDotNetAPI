using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
    public class Achievements
    {
        public IEnumerable<int> achievementsCompleted { get; set; }
        public IEnumerable<long> achievementsCompletedTimestamp { get; set; }
        public IEnumerable<int> criteria { get; set; }
        public IEnumerable<int> criteriaQuantity { get; set; }
        public IEnumerable<long> criteriaTimestamp { get; set; }
        public IEnumerable<long> criteriaCreated { get; set; }
    }
}
