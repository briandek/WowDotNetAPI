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
    public class AuctionTest
    {
        private void testRealm(Region region, string realm)
        {
            WowExplorer explorer = new WowExplorer(Region.US);

            Auctions auctions = explorer.GetAuctions("Skullcrusher");

            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
            Assert.IsTrue((from n in auctions.Horde.Auctions where n.ItemId == 53010 select n).Count() > 0);
        }

        [TestMethod]
        public void testRealms()
        {
            this.testRealm(Region.US, "Skullcrusher");
            this.testRealm(Region.EU, "Twisting Nether");
            this.testRealm(Region.TW, "暴風祭壇");
        }
    }
}
