using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models
{
    public interface IRealm
    {
        string name { get; set; }
        string slug { get; set; }
        string type { get; set; }
        bool status { get; set; }
        bool queue { get; set; }
        string population { get; set; }
    }
}
