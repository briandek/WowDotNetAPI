using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual(UnitSide.ALLIANCE, TestUtil.immortalityGuild.Side);
            Assert.IsTrue(TestUtil.immortalityGuild.Members.Any());
        }

        [TestMethod]
        public void Get_Valid_Human_Member_From_Immortality_Guild()
        {
            GuildMember briandek = TestUtil.immortalityGuild.Members.Where(m => m.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            Assert.IsTrue(briandek.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));

            //Assert.AreEqual(Character
            Assert.AreEqual(85, briandek.Character.Level);
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.Character.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Character.Gender);


            //Assert.IsTrue(briandek.character.achievementPoints == 6895); achievements via guild api is broken ._.

        }


        [TestMethod]
        public void Get_Valid_Night_Elf_Member_From_Immortality_Guild()
        {
            GuildMember fleas = TestUtil.immortalityGuild.Members.Where(m => m.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            
            Assert.IsTrue(fleas.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(85, fleas.Character.Level);
            Assert.AreEqual(CharacterClass.DRUID, fleas.Character.@Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, fleas.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, fleas.Character.Gender);
        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            Guild dvGuild = TestUtil.WowExplorer.GetGuild("laughing skull", "deus vox", true, false);

            Assert.IsTrue(dvGuild.Name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.Realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.Members.Any());

            Assert.AreEqual(UnitSide.ALLIANCE, dvGuild.Side );


            GuildMember ohnoes = dvGuild.Members.Where(m => m.Character.Name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            
            Assert.IsTrue(ohnoes.Character.Name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(85, ohnoes.Character.Level);
            Assert.AreEqual(CharacterClass.ROGUE, ohnoes.Character.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, ohnoes.Character.Race);
            Assert.AreEqual(CharacterGender.FEMALE, ohnoes.Character.Gender);


        }


        [TestMethod]
        public void Get_Valid_Member_From_Horde_Guild()
        {
            Guild rageGuild = TestUtil.WowExplorer.GetGuild("skullcrusher", "rage", true, false);

            Assert.IsTrue(rageGuild.Name.Equals("rage", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(rageGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(rageGuild.Members.Any());

            Assert.IsTrue(rageGuild.Side == UnitSide.HORDE);
        }
    }
}
