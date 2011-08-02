using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Test;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AuctionTest
    {
        [TestMethod]
        public void testAuctionsCount()
        {
            Assert.IsTrue(TestUtility.WowExplorer.GetAuctions("Skullcrusher").Horde.Auctions.Count() > 0);

        }
    }
}
