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
        private void testRealm(Region region, string realm)
        {
            WowExplorer explorer = new WowExplorer(region);

            Auctions auctions = explorer.GetAuctions(realm);

            Assert.IsTrue(auctions.Horde.Auctions.Count() > 0);
            Assert.IsTrue((from n in auctions.Horde.Auctions where n.ItemId == 53010 select n).Count() > 0);
        }

        [TestMethod]
        public void Get_Simple_Auction_Data_From_US_Realm()
        {
            this.testRealm(Region.US, "Skullcrusher");
        }

        [TestMethod]
        public void Get_Simple_Auction_Data_From_EU_Realm()
        {
            this.testRealm(Region.EU, "Twisting Nether");
        }

        // BROKEN
        //[TestMethod]
        //public void testTwRealm()
        //{
        //    this.testRealm(Region.TW, "Balnazzar");
        //}   
    }
}
