using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Test;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class ItemTests
    {
        private static WowExplorer explorer;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US);
        }

        [TestMethod]
        public void Get_Sample_Item_38268()
        {
            var sampleItem = explorer.GetItem("38268");

            Assert.AreEqual("Spare Hand", sampleItem.Name);
            Assert.AreEqual("Give to a Friend", sampleItem.Description);
            Assert.AreEqual("inv_gauntlets_09", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(0, sampleItem.ItemBind);
            Assert.AreEqual("CREATURE_PICKPOCKET", sampleItem.ItemSource.SourceType);
            Assert.AreEqual(2, sampleItem.WeaponInfo.Damage.MaxDamage);
        }



        [TestMethod]
        public void Get_Sample_Item_39564()
        {
            var sampleItem = explorer.GetItem("39564");

            Assert.AreEqual(@"Heroes' Bonescythe Legplates", sampleItem.Name);
            Assert.AreEqual("", sampleItem.Description);
            Assert.AreEqual("inv_pants_mail_15", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(1, sampleItem.ItemBind);
            Assert.AreEqual("VENDOR", sampleItem.ItemSource.SourceType);

            Assert.AreEqual(null, sampleItem.WeaponInfo);

            Assert.AreEqual(4, sampleItem.AllowableClasses.First());
            Assert.AreEqual(37, sampleItem.BonusStats.ElementAt(2).Amount);

            Assert.AreEqual("BLUE", sampleItem.SocketInfo.Sockets.First().Type);


        }

        [TestMethod]
        public void Get_Sample_Item_17182()
        {
            var sampleItem = explorer.GetItem("17182");

            Assert.AreEqual("Sulfuras, Hand of Ragnaros", sampleItem.Name);
            Assert.AreEqual("", sampleItem.Description);
            Assert.AreEqual("inv_hammer_unique_sulfuras", sampleItem.Icon);
            Assert.AreEqual(1, sampleItem.Stackable);
            Assert.AreEqual(1, sampleItem.ItemBind);

            Assert.AreEqual("CREATED_BY_SPELL", sampleItem.ItemSource.SourceType);

            Assert.AreEqual(3.7, sampleItem.WeaponInfo.WeaponSpeed);

            Assert.AreEqual(12, sampleItem.BonusStats.ElementAt(2).Amount);
            Assert.AreEqual("Hurls a fiery ball that causes 303 Fire damage and an additional 75 damage over 10 sec.",
                sampleItem.ItemSpells.First().Spell.Description);
        }

    }
}
