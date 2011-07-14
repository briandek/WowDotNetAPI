using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Explorers.Models
{
    public class RealmList
    {
        public IEnumerable<Realm> realms { get; set; }
    }
}
