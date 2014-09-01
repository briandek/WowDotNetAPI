using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuctionTests
    {
        private static WowExplorer explorer;
        private static string APIKey = "";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_US_Realm_Auction_Data()
        {
            Auctions auctions = explorer.GetAuctions("Skullcrusher");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
        }

        [TestMethod]
        public void Get_EU_Realm_Auction_Data()
        {
            WowExplorer euExplorer = new WowExplorer(Region.EU, Locale.fr_FR, APIKey);

            Auctions auctions = euExplorer.GetAuctions("Twisting Nether");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
        }

        [TestMethod]
        public void Get_TW_Realm_Auction_Data()
        {
            WowExplorer twExplorer = new WowExplorer(Region.TW, Locale.zh_TW, APIKey);
            
            Auctions auctions = twExplorer.GetAuctions("Balnazzar");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
        }
    }
}