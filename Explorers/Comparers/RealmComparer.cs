using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Comparers
{
    public class RealmComparer : EqualityComparer<Realm>
    {
        public override bool Equals(Realm a, Realm b)
        {
            if (a == null || b == null) return false;

            return a.Name == b.Name
                && a.Population == b.Population
                && a.Queue == b.Queue
                && a.Slug == b.Slug
                && a.Status == b.Status
                && a.Type == b.Type;
        }

        public override int GetHashCode(Realm a)
        {
            return string.Concat(a.Name, a.Type).GetHashCode();
        }
    }
}
