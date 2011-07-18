using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Models;
using System.Web.Script.Serialization;

namespace WowDotNetAPI.Extensions
{
    public static class RealmExtensions
    {
        public static Realm GetRealm(this IEnumerable<Realm> realms, string name)
        {
            return realms.Where(r => r.name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        public static IEnumerable<Realm> WithQueues(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => r.queue);
        }

        public static IEnumerable<Realm> WithoutQueues(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => !r.queue);
        }

        public static IEnumerable<Realm> ThatAreUp(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => r.status);
        }

        public static IEnumerable<Realm> ThatAreDown(this IEnumerable<Realm> realms)
        {
            return realms.Where(r => !r.status);
        }

        public static IEnumerable<Realm> WithPopulation(this IEnumerable<Realm> realms, string Population)
        {
            return realms.Where(r => r.population.Equals(Population, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Realm> WithType(this IEnumerable<Realm> realms, string realmType)
        {
            return realms.Where(r => r.type.Equals(realmType, StringComparison.InvariantCultureIgnoreCase));
        }

        public static string ToJson(this IEnumerable<Realm> realms, JavaScriptSerializer JavascriptSerializer)
        {
            return JavascriptSerializer.Serialize(new Dictionary<string, IEnumerable<Realm>> { { "realms", realms } });
        }
    }
}
