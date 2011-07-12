using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers;
using WowDotNetAPI.Explorers.CharacterExplorerModels;
using WowDotNetAPI.Explorers.Comparers;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Extensions;
using WowDotNetAPI.Explorers.Test;

namespace Explorers.Test
{
	[TestClass]
	public class RealmExplorerTest
	{
		

		[TestMethod]
		public void GetAll_US_Realms_Returns_All_Realms()
		{
			IEnumerable<Realm> realmList = TestUtil.rE.GetAllRealms();
			Assert.IsTrue(realmList.Any());
		}

		[TestMethod]
		public void Get_Valid_US_Realm_Returns_Unique_Realm()
		{
			var realm = TestUtil.rE.GetRealm("skullcrusher");

			Assert.IsTrue(realm.name == "Skullcrusher");
			Assert.IsTrue(realm.type == "pvp");
			Assert.IsTrue(realm.slug == "skullcrusher");
		}

		[TestMethod]
		public void Get_Invalid_US_Realm_Returns_Null()
		{
			var realm = TestUtil.rE.GetRealm("dekuz");
			Assert.IsNull(realm);
		}

		[TestMethod]
		public void Get_Null_US_Realm_Returns_Null()
		{
			var realm = TestUtil.rE.GetRealm(null);
			Assert.IsNull(realm);
		}

		[TestMethod]
		public void Get_All_Realms_By_Type_Returns_Pvp_Realms()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.Realms.WithType("pvp");
			var allCollectedRealmsArePvp = realmList.Any() &&
				realmList.All(r => r.type.Equals("pvp", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(allCollectedRealmsArePvp);
		}

		[TestMethod]
		public void Get_All_Realms_By_Status_Returns_Realms_That_Are_Up()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.Realms.ThatAreUp();

			//All servers being down is likely(maintenance) and will cause test to fail
			var allCollectedRealmsAreUp = realmList.Any() &&
				realmList.All(r => r.status == true);

			Assert.IsTrue(allCollectedRealmsAreUp);
		}


		[TestMethod]
		public void Get_All_Realms_By_Queue_Returns_Realms_That_Do_Not_Have_Queues()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.Realms.WithoutQueues();

			//All servers getting queues is unlikely but possible and will cause test to fail
			var allCollectedRealmsHaveQueues = realmList.Any() &&
				realmList.All(r => r.queue == false);

			Assert.IsTrue(allCollectedRealmsHaveQueues);
		}

		[TestMethod]
		public void Get_All_Realms_By_Population_Returns_Realms_That_Have_Low_Population()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.Realms.WithPopulation("low");
			var allCollectedRealmsHaveLowPopulation = realmList.Any() &&
				realmList.All(r => r.population.Equals("low", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(allCollectedRealmsHaveLowPopulation);
		}

		[TestMethod]
		public void Get_Realms_Using_Multiple_ValidNames_Query_Returns_Valid_Results()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealms("Skullcrusher", "Laughing Skull", "Blade's Edge");

			var allCollectedRealmsAreValid = realmList.Any() &&
				realmList.All(r => r.name.Equals("Skullcrusher", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("Laughing Skull", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("Blade's Edge", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(realmList.Count() == 3);
			Assert.IsTrue(allCollectedRealmsAreValid);
		}

		[TestMethod]
		public void Get_Realms_Using_Multiple_InvalidNames_Query_Returns_One_Valid_Result()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealms("Blade's Edge", "AZUZU!", "dekuz");

			var allCollectedRealmsAreValid = realmList.Any() &&
				realmList.All(r => r.name.Equals("Blade's Edge", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("AZUZU!", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("dekuz", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(realmList.Count() == 1);
			Assert.IsTrue(allCollectedRealmsAreValid);
		}

		[TestMethod]
		public void Get_Realms_Using_Multiple_ValidNamesArray_Query_Returns_Valid_Results()
		{
			var namesList = new string[] { "Blade's Edge", "Aegwynn", "Area 52" };

            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealms(namesList);

			var allCollectedRealmsAreValid = realmList.Any() &&
				realmList.All(r => r.name.Equals("Blade's Edge", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("Aegwynn", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("Area 52", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(realmList.Count() == 3);
			Assert.IsTrue(allCollectedRealmsAreValid);
		}

		[TestMethod]
		public void Get_Realms_Using_Multiple_InvalidNamesArray_Query_Still_Returns_Valid_Realm_List()
		{
			var namesList = new string[] { "Aioros", "Aioria", "Shiryu" };
            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealms(namesList);

			Assert.IsNotNull(realmList);
            Assert.IsTrue(realmList.Any());
		}

		[TestMethod]
		public void Get_Realms_Using_Valid_Query_Returns_Valid_Results()
		{
            TestUtil.rE.Refresh();
            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealmsViaQuery("?realm=Medivh&realm=Blackrock");

			var allCollectedRealmsAreValid = realmList.Any() &&
				realmList.All(r => r.name.Equals("Medivh", StringComparison.InvariantCultureIgnoreCase)
					|| r.name.Equals("Blackrock", StringComparison.InvariantCultureIgnoreCase));


			Assert.IsTrue(realmList.Count() == 2);
			Assert.IsTrue(allCollectedRealmsAreValid);
		}

		[TestMethod]
		public void Get_Realms_Using_Invalid_Realm_Name_In_Query_Returns_Valid_Full_Realm_List()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealmsViaQuery("?realm=!!adfasdza...12");
			Assert.IsNotNull(realmList);
            Assert.IsTrue(realmList.Any());
		}

		[TestMethod]
		public void Get_Realms_Using_Garbage_Query_Still_Returns_All_Realms()
		{
            IEnumerable<Realm> realmList = TestUtil.rE.GetMultipleRealmsViaQuery("?asdf2&asdf");

			Assert.IsNotNull(realmList);
			Assert.IsTrue(realmList.Any());
		}

        [TestMethod]
        public void GetAllRealms_InvalidRegion_URL_Throws_WebException()
        {
            ThrowsException<WebException>(() => TestUtil.rE.Region = "foo", "The remote name could not be resolved: 'foo.battle.net'");

            TestUtil.rE = new RealmExplorer();
        }
        
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
