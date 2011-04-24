using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealmAPI
{
    public class RealmComparer : EqualityComparer<Realm>
    {

        public override bool Equals(Realm x, Realm y)
        {
            if (x == null || y == null) return false;

            return x.name == y.name
                && x.population == y.population
                && x.queue == y.queue
                && x.slug == y.slug
                && x.status == y.status
                && x.type == y.type;
        }

        public override int GetHashCode(Realm obj)
        {
            return string.Concat(obj.name, obj.type).GetHashCode();
        }
    }
}
