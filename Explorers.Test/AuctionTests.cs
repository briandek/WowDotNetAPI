using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuctionTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Auction_Data()
        {
            Auctions auctions = explorer.GetAuctions("skullcrusher");
            Assert.IsTrue(auctions.CurrentAuctions.Count() > 0);
        }
    }
}