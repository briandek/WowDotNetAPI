using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using WowDotNet.Explorers.Models;

namespace WowDotNet.Explorers.Comparers
{
    public class RealmComparer : EqualityComparer<Realm>
    {

        public override bool Equals(Realm a, Realm b)
        {
            if (a == null || b == null) return false;

            return a.name == b.name
                && a.population == b.population
                && a.queue == b.queue
                && a.slug == b.slug
                && a.status == b.status
                && a.type == b.type;
        }

        public override int GetHashCode(Realm a)
        {
            return string.Concat(a.name, a.type).GetHashCode();
        }
    }
}
