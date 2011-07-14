using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Utilities;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class GuildExplorerTest
    {

        [TestMethod]
        public void Get_Simple_Guild_Immortality_From_Skullcrusher()
        {
            Assert.IsTrue(TestUtil.immortalityGuild.realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(TestUtil.immortalityGuild.members.Any());
        }

        [TestMethod]
        public void Get_Valid_Member_From_Immortality_Guild()
        {
            GuildMember briandek = TestUtil.immortalityGuild.members.Where(m => m.character.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            Assert.IsTrue(briandek.character.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.character.@class == 1);
            Assert.IsTrue(briandek.character.gender == 0);
            //Assert.IsTrue(briandek.character.achievementPoints == 6895); achievements via guild api is broken ._.

        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            Guild dvGuild = TestUtil.gE.GetGuild("laughing skull", "deus vox", true, false);

            Assert.IsTrue(dvGuild.name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.members.Any());


            GuildMember ohnoes = dvGuild.members.Where(m => m.character.name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            Assert.IsTrue(ohnoes.character.name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(ohnoes.character.@class == 4);
            Assert.IsTrue(ohnoes.character.gender == 1);
        }
    }
}
