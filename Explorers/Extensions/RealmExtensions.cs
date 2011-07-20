using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Models;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WowDotNetAPI.Extensions
{
    public static class RealmExtensions
    {
        public static Realm GetRealm(this IEnumerable<Realm> realms, string name)
        {
            return realms.Where(r => r.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        public static IEnumerable<Realm> WithQueues(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => r.Queue);
        }

        public static IEnumerable<Realm> WithoutQueues(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => !r.Queue);
        }

        public static IEnumerable<Realm> ThatAreUp(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => r.Status);
        }

        public static IEnumerable<Realm> ThatAreDown(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => !r.Status);
        }

        public static IEnumerable<Realm> WithPopulation(this IEnumerable<Realm> realms, string Population)
        {
            return realms.Where(r => r.Population.Equals(Population, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Realm> WithType(this IEnumerable<Realm> realms, string realmType)
        {
            return realms.Where(r => r.Type.Equals(realmType, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
