using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
    public class Achievements
    {
        public List<int> achievementsCompleted { get; set; }
        public List<long> achievementsCompletedTimestamp { get; set; }
        public List<int> criteria { get; set; }
        public List<int> criteriaQuantity { get; set; }
        public List<long> criteriaTimestamp { get; set; }
        public List<long> criteriaCreated { get; set; }
    }
}
