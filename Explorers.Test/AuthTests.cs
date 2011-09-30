using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuthTests
    {
        private static WowExplorer explorer;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US);
        }

        [TestMethod]
        public void FetchData_When_Authenticated()
        {
            WowExplorer authExplorer = new WowExplorer(Region.US, Locale.en_US, "", "");

            IEnumerable<Realm> realms = authExplorer.GetRealms();

            Realm realm = realms.GetRealm("skullcrusher");
            Assert.IsNotNull(realm);
            Assert.IsTrue(realm.Name == "Skullcrusher");
            Assert.IsTrue(realm.Type == RealmType.PVP);
            Assert.IsTrue(realm.Slug == "skullcrusher");
        }
    }
}
