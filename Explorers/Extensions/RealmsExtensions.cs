using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Extensions
{
    public static class RealmsExtensions
    {
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

        public static IEnumerable<Realm> WithPopulation(this IEnumerable<Realm> realms, string population)
        {
            return realms.Where(r => r.population.Equals(population, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Realm> WithType(this IEnumerable<Realm> realms, string realmType)
        {
            return realms.Where(r => r.type.Equals(realmType, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
