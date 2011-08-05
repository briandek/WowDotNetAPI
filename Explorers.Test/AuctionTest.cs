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
        [TestMethod]
        public void testAuctionsCount()
        {
            Auctions actions = TestUtility.WowExplorer.GetAuctions("Skullcrusher");

            Assert.IsTrue(actions.Horde.Auctions.Count() > 0);
            Assert.IsTrue((from n in actions.Horde.Auctions where n.ItemId == 53010 select n).Count() > 0);

        }
    }
}
