using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers;
using WowDotNetAPI.Explorers.Models;
using WowDotNetAPI.Explorers.Comparers;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Extensions;
using WowDotNetAPI.Explorers.Test;

namespace Explorers.Test
{
	[TestClass]
	public class RealmTest
	{
		

		[TestMethod]
		public void GetAll_US_Realms_Returns_All_Realms()
		{
			IEnumerable<Realm> realmList = TestUtil.WowExplorer.GetRealms("us");
			Assert.IsTrue(realmList.Any());
		}

		[TestMethod]
		public void Get_Valid_US_Realm_Returns_Unique_Realm()
		{
			Realm realm = TestUtil.realms.GetRealm("skullcrusher");

			Assert.IsTrue(realm.name == "Skullcrusher");
			Assert.IsTrue(realm.type == "pvp");
			Assert.IsTrue(realm.slug == "skullcrusher");
		}

		[TestMethod]
		public void Get_All_Realms_By_Type_Returns_Pvp_Realms()
		{
            IEnumerable<Realm> realmList = TestUtil.realms.WithType("pvp");
			var allCollectedRealmsArePvp = realmList.Any() &&
				realmList.All(r => r.type.Equals("pvp", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(allCollectedRealmsArePvp);
		}

		[TestMethod]
		public void Get_All_Realms_By_Status_Returns_Realms_That_Are_Up()
		{
            IEnumerable<Realm> realmList = TestUtil.realms.ThatAreUp();

			//All servers being down is likely(maintenance) and will cause test to fail
			var allCollectedRealmsAreUp = realmList.Any() &&
				realmList.All(r => r.status == true);

			Assert.IsTrue(allCollectedRealmsAreUp);
		}


		[TestMethod]
		public void Get_All_Realms_By_Queue_Returns_Realms_That_Do_Not_Have_Queues()
		{
            IEnumerable<Realm> realmList = TestUtil.realms.WithoutQueues();

			//All servers getting queues is unlikely but possible and will cause test to fail
			var allCollectedRealmsHaveQueues = realmList.Any() &&
				realmList.All(r => r.queue == false);

			Assert.IsTrue(allCollectedRealmsHaveQueues);
		}

		[TestMethod]
		public void Get_All_Realms_By_Population_Returns_Realms_That_Have_Low_Population()
		{
            IEnumerable<Realm> realmList = TestUtil.realms.WithPopulation("low");
			var allCollectedRealmsHaveLowPopulation = realmList.Any() &&
				realmList.All(r => r.population.Equals("low", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsTrue(allCollectedRealmsHaveLowPopulation);
		}

        public void GetAllRealms_InvalidRegion_URL_Throws_WebException()
        {
            ThrowsException<WebException>(() => TestUtil.WowExplorer.GetRealms("foo"), "The remote name could not be resolved: 'foo.battle.net'");
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
