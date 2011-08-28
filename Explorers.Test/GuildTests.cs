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
    public class GuildTests
    {

        [TestMethod]
        public void Get_Simple_Guild_Immortality_From_Skullcrusher()
        {
            Assert.IsTrue(TestUtility.immortalityGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, TestUtility.immortalityGuild.Side);
            Assert.IsTrue(TestUtility.immortalityGuild.Members.Any());
        }

        [TestMethod]
        public void Get_Valid_Human_Member_From_Immortality_Guild()
        {
            GuildMember briandek = TestUtility.immortalityGuild.Members.Where(m => m.Character.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

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
            GuildMember fleas = TestUtility.immortalityGuild.Members.Where(m => m.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            
            Assert.IsTrue(fleas.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(85, fleas.Character.Level);
            Assert.AreEqual(CharacterClass.DRUID, fleas.Character.@Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, fleas.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, fleas.Character.Gender);
        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            Guild dvGuild = TestUtility.WowExplorer.GetGuild("laughing skull", "deus vox", GuildOptions.GetMembers | GuildOptions.GetAchievements);

            Assert.IsNotNull(dvGuild.Members);
            Assert.IsNotNull(dvGuild.AchievementPoints);

            Assert.IsTrue(dvGuild.Name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.Realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.Members.Any());

            Assert.AreEqual(UnitSide.ALLIANCE, dvGuild.Side );

            //need to find a valid horde character - or better mock this!
            //GuildMember ohnoes = dvGuild.Members.Where(m => m.Character.Name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            //Assert.IsTrue(ohnoes.Character.Name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase));

            //Assert.AreEqual(85, ohnoes.Character.Level);
            //Assert.AreEqual(CharacterClass.ROGUE, ohnoes.Character.@Class);
            //Assert.AreEqual(CharacterRace.HUMAN, ohnoes.Character.Race);
            //Assert.AreEqual(CharacterGender.FEMALE, ohnoes.Character.Gender);
        }


        [TestMethod]
        public void Get_Valid_Member_From_Horde_Guild()
        {
            Guild rageGuild = TestUtility.WowExplorer.GetGuild("skullcrusher", "rage", GuildOptions.GetMembers);

            Assert.IsNotNull(rageGuild.Members);
            Assert.IsNull(rageGuild.Achievements);

            Assert.IsTrue(rageGuild.Name.Equals("rage", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(rageGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
           
            Assert.IsTrue(rageGuild.Members.Any());

            Assert.IsTrue(rageGuild.Side == UnitSide.HORDE);
        }

        [TestMethod]
        public void Get_Guild_With_Only_Achievements()
        {
            Guild immortality = TestUtility.WowExplorer.GetGuild("skullcrusher", "immortality", GuildOptions.GetAchievements);

            Assert.IsNull(immortality.Members);
            Assert.IsNotNull(immortality.Achievements);

            Assert.IsTrue(TestUtility.immortalityGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, TestUtility.immortalityGuild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Only_Members()
        {
            Guild immortality = TestUtility.WowExplorer.GetGuild("skullcrusher", "immortality", GuildOptions.GetMembers);

            Assert.IsNotNull(immortality.Members);
            Assert.IsNull(immortality.Achievements);

            Assert.IsTrue(TestUtility.immortalityGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, TestUtility.immortalityGuild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Only_No_Options()
        {
            Guild immortality = TestUtility.WowExplorer.GetGuild("skullcrusher", "immortality", GuildOptions.None);

            Assert.IsNull(immortality.Members);
            Assert.IsNull(immortality.Achievements);

            Assert.IsTrue(TestUtility.immortalityGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, TestUtility.immortalityGuild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Base_Method_Call()
        {
            Guild immortality = TestUtility.WowExplorer.GetGuild("skullcrusher", "immortality");

            Assert.IsNull(immortality.Members);
            Assert.IsNull(immortality.Achievements);

            Assert.IsTrue(TestUtility.immortalityGuild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, TestUtility.immortalityGuild.Side);
        }
    }
}
