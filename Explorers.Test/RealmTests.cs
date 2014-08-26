using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WowDotNetAPI;
using WowDotNetAPI.Models;
using WowDotNetAPI.Test;
using WowDotNetAPI.Utilities;

namespace Explorers.Test
{
    [TestClass]
    public class RealmTests
    {
        private static WowExplorer explorer;
        private static string APIKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void GetAll_US_Realms_Returns_All_Realms()
        {
            var realmList = explorer.GetRealms();
            Assert.IsTrue(realmList.Any());
        }

        [TestMethod]
        public void Get_Valid_US_Realm_Returns_Unique_Realm()
        {
            var realm = explorer.GetRealms().Where(r => r.Name.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            Assert.IsNotNull(realm);
            Assert.IsTrue(realm.Name == "Skullcrusher");
            Assert.IsTrue(realm.Type == RealmType.PVP);
            Assert.IsTrue(realm.Slug == "skullcrusher");
        }

        [TestMethod]
        public void Get_All_Realms_By_Type_Returns_Pvp_Realms()
        {
            var realms = explorer.GetRealms().Where(r => r.Type == RealmType.PVP);
            var allCollectedRealmsArePvp = realms.Any() && realms.All(r => r.Type == RealmType.PVP);
            Assert.IsTrue(allCollectedRealmsArePvp);
        }

        [TestMethod]
        public void Get_All_Realms_By_Status_Returns_Realms_That_Are_Up()
        {
            var realmList = explorer.GetRealms().Where(r => r.Status == true);
            //All servers being down is likely(maintenance) and will cause test to fail
            var allCollectedRealmsAreUp = realmList.Any() && realmList.All(r => r.Status == true);
            Assert.IsTrue(allCollectedRealmsAreUp);
        }


        [TestMethod]
        public void Get_All_Realms_By_Queue_Returns_Realms_That_Do_Not_Have_Queues()
        {
            var realmList = explorer.GetRealms().Where(r => r.Queue == false);
            //All servers getting queues is unlikely but possible and will cause test to fail
            var allCollectedRealmsHaveQueues = realmList.Any() && realmList.All(r => r.Queue == false);
            Assert.IsTrue(allCollectedRealmsHaveQueues);
        }

        [TestMethod]
        public void Get_All_Realms_By_Population_Returns_Realms_That_Have_Low_Population()
        {
            var realmList = explorer.GetRealms().Where(r => r.population == "low");
            var allCollectedRealmsHaveLowPopulation = realmList.Any() && realmList.All(r => r.population == "low");
            Assert.IsTrue(allCollectedRealmsHaveLowPopulation);
        }

        
    }
}
