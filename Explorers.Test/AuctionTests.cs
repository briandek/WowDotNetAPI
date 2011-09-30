using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;
using WowDotNetAPI.Test;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuctionTests
    {
        private static WowExplorer explorer;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US);
        }

        [TestMethod]
        public void testUsRealm()
        {
            Auctions auctions = explorer.GetAuctions("Skullcrusher");
            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
            // Is this check really necessary?
            Assert.IsTrue((from n in auctions.Horde.Auctions where n.ItemId == 53010 select n).Count() > 0);
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
