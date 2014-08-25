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
        public void testUsRealm()
        {
            Auctions auctions = explorer.GetAuctions("Skullcrusher");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
        }

        [TestMethod]
        public void testEuRealm()
        {
            explorer.Region = Region.EU;
            Auctions auctions = explorer.GetAuctions("Twisting Nether");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
        }

        [TestMethod]
        public void testTwRealm()
        {
            explorer.Region = Region.TW;
            Auctions auctions = explorer.GetAuctions("Balnazzar");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
        }
    }
}