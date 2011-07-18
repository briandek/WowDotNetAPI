using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Interfaces;
using WowDotNetAPI.Utilities;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class GuildTest
    {

        [TestMethod]
        public void Get_Simple_Guild_Immortality_From_Skullcrusher()
        {
            Assert.IsTrue(TestUtil.immortalityGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(TestUtil.immortalityGuild.Members.Any());
        }

        [TestMethod]
        public void Get_Valid_Member_From_Immortality_Guild()
        {
            GuildMember briandek = TestUtil.immortalityGuild.Members.Where(m => m.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            Assert.IsTrue(briandek.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.Character.@Class == 1);
            Assert.IsTrue(briandek.Character.Gender == 0);
            //Assert.IsTrue(briandek.character.achievementPoints == 6895); achievements via guild api is broken ._.

        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            Guild dvGuild = TestUtil.WowExplorer.GetGuild("laughing skull", "deus vox", true, false);

            Assert.IsTrue(dvGuild.Name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.Realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.Members.Any());


            GuildMember ohnoes = dvGuild.Members.Where(m => m.Character.Name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            Assert.IsTrue(ohnoes.Character.Name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(ohnoes.Character.@Class == 4);
            Assert.IsTrue(ohnoes.Character.Gender == 1);
        }
    }
}
