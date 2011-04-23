using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace RealmAPI.Test
{
    [TestClass]
    public class RealmExplorerTest
    {
        RealmExplorer rE;

        [TestInitialize]
        public void Setup()
        {
            rE = new RealmExplorer();
        }

        //us - Americas; 241 realms as of 04/22/2011
        [TestMethod]
        public void GetAll_US_Realms_Returns_All_Realms()
        {
            var realmList = rE.GetAllRealms();
            Assert.IsTrue(realmList.Count() >= 241);
        }

        [TestMethod]
        public void Get_Valid_US_Realm_Returns_Unique_Realm()
        {
            var realm = rE.GetRealm("skullcrusher");

            Assert.IsTrue(realm.name == "Skullcrusher");
            Assert.IsTrue(realm.type == "pvp");
            Assert.IsTrue(realm.slug == "skullcrusher");
        }

        [TestMethod]
        public void Get_Invalid_US_Realm_Returns_Null()
        {
            var realm = rE.GetRealm("dekuz");
            Assert.IsNull(realm);
        }

        [TestMethod]
        public void Get_All_Realms_By_Type_Returns_Pvp_Realms()
        {
            var realmList = rE.GetAllRealmsByType("pvp");
            var allCollectedRealmsArePvp = realmList
                .TrueForAll(r => r.type.Equals("pvp", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(allCollectedRealmsArePvp);
        }

        [TestMethod]
        public void Get_All_Realms_By_Status_Returns_Realms_That_Are_Up()
        {
            var realmList = rE.GetAllRealmsByStatus(true);
            var allCollectedRealmsAreUp = realmList
                .TrueForAll(r => r.status == true);

            Assert.IsTrue(allCollectedRealmsAreUp);
        }

        [TestMethod]
        public void Get_All_Realms_By_Queue_Returns_Realms_That_Have_Queues()
        {
            var realmList = rE.GetAllRealmsByQueue(true);
            var allCollectedRealmsHaveQueues = realmList
                .TrueForAll(r => r.queue == false);

            Assert.IsTrue(allCollectedRealmsHaveQueues);
        }

        [TestMethod]
        public void Get_All_Realms_By_Population_Returns_Realms_That_Have_Low_Population()
        {
            var realmList = rE.GetAllRealmsByPopulation("low");
            var allCollectedRealmsHaveLowPopulation = realmList
                .TrueForAll(r => r.population.Equals("low", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(allCollectedRealmsHaveLowPopulation);
        }

        [TestMethod]
        public void Get_Realms_Using_Multiple_ValidNames_Query_Returns_Valid_Results()
        {
            var realmList = rE.GetRealms("Skullcrusher", "Laughing Skull", "Blade's Edge");

            var allCollectedRealmsAreValid = realmList
                .TrueForAll(r => r.name.Equals("Skullcrusher", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("Laughing Skull", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("Blade's Edge", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(realmList.Count() == 3);
            Assert.IsTrue(allCollectedRealmsAreValid);
        }

        [TestMethod]
        public void Get_Realms_Using_Multiple_InvalidNames_Query_Returns_One_Valid_Result()
        {
            var realmList = rE.GetRealms("Blade's Edge", "AZUZU!", "dekuz");

            var allCollectedRealmsAreValid = realmList
                .TrueForAll(r => r.name.Equals("Blade's Edge", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("AZUZU!", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("dekuz", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(realmList.Count() == 1);
            Assert.IsTrue(allCollectedRealmsAreValid);
        }

        [TestMethod]
        public void Get_Realms_Using_Multiple_ValidNamesArray_Query_Returns_Valid_Results()
        {
            var namesList = new string[] { "Blade's Edge", "Aegwynn", "Area 52" };

            var realmList = rE.GetRealms(namesList);

            var allCollectedRealmsAreValid = realmList
                .TrueForAll(r => r.name.Equals("Blade's Edge", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("Aegwynn", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("Area 52", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(realmList.Count() == 3);
            Assert.IsTrue(allCollectedRealmsAreValid);
        }

        [TestMethod]
        public void Get_Realms_Using_Multiple_InvalidNamesArray_Query_Returns_Null()
        {
            var namesList = new string[] { "Aioros", "Aioria", "Shiryu" };
            var realmList = rE.GetRealms(namesList);

            Assert.IsNull(realmList);
        }

        [TestMethod]
        public void Get_Realms_Using_Valid_Query_Returns_Valid_Results()
        {
            var realmList = rE.GetRealmsViaQuery("?realm=Medivh&realm=Blackrock");

            var allCollectedRealmsAreValid = realmList
                .TrueForAll(r => r.name.Equals("Medivh", StringComparison.InvariantCultureIgnoreCase)
                    || r.name.Equals("Blackrock", StringComparison.InvariantCultureIgnoreCase));


            Assert.IsTrue(realmList.Count() == 2);
            Assert.IsTrue(allCollectedRealmsAreValid);
        }

        [TestMethod]
        public void Get_Realms_Using_Invalid_Realm_Name_In_Query_Returns_Null()
        {
            var realmList = rE.GetRealmsViaQuery("?realm=!!adfasdza...12");
            Assert.IsNull(realmList);
        }

        [TestMethod]
        public void Get_Realms_Using_Garbage_Query_Still_Returns_All_Realms()
        {
            var realmList = rE.GetRealmsViaQuery("?asdf2&asdf");

            Assert.IsNotNull(realmList);
            Assert.IsTrue(realmList.Count() >= 241);
        }

        //eu - Europe; 265 realms as of 04/22/2011
        [TestMethod]
        public void GetAll_EU_Realms_Returns_All_EU_Realms()
        {
            rE.region = "eu";
            var realmList = rE.GetAllRealms();
            Assert.IsTrue(realmList.Count() >= 265);
        }

        [TestMethod]
        public void Get_Valid_EU_Realm_Returns_Unique_EU_Realm()
        {
            rE.region = "eu";
            var realm = rE.GetRealm("drek'thar");

            Assert.IsTrue(realm.name == "Drek'Thar");
            Assert.IsTrue(realm.type == "pve");
            Assert.IsTrue(realm.slug == "drekthar");
        }

        [TestMethod]
        public void Get_Invalid_EU_Realm_Returns_Null()
        {
            rE.region = "eu";
            var realm = rE.GetRealm("dekuz");
            Assert.IsNull(realm);
        }

        //kr - Korea; 33 realms as of 04/22/2011
        [TestMethod]
        public void GetAll_KR_Realms_Returns_All_KR_Realms()
        {
            rE.region = "kr";
            var realmList = rE.GetAllRealms();
            Assert.IsTrue(realmList.Count() >= 33);
        }

        [TestMethod]
        public void Get_Valid_KR_Realm_Returns_Unique_KR_Realm()
        {
            rE.region = "kr";
            var realm = rE.GetRealm("kul tiras");

            Assert.IsTrue(realm.name == "Kul Tiras");
            Assert.IsTrue(realm.type == "pvp");
            Assert.IsTrue(realm.slug == "kul-tiras");
        }

        [TestMethod]
        public void Get_Invalid_KR_Realm_Returns_Null()
        {
            rE.region = "kr";
            var realm = rE.GetRealm("dekuz");
            Assert.IsNull(realm);
        }

        [TestMethod]
        public void GetAllRealms_InvalidRegion_URL_Throws_WebException()
        {
            rE.region = "foo";
            ThrowsException<WebException>(() => rE.GetAllRealms(), "The remote name could not be resolved: 'foo.battle.net'");
        }

        //tw - Taiwan
        //sea - Southeast Asia
        //china - China

        //Assert.ThrowException 
        public static void ThrowsException<T>(Action action, string expectedMessage) where T : Exception
        {
            try
            {
                action.Invoke();
                Assert.Fail("Exception of type {0} should be thrown", typeof(T));
            }
            catch (T e)
            {
                Assert.AreEqual(expectedMessage, e.Message);
            }
        }
    }
}
