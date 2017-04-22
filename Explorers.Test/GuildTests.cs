using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Utilities;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;
using WowDotNetAPI.Explorers.Test;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class GuildTests
    {
        private static WowExplorer explorer;
        private static Guild guild;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
            guild = explorer.GetGuild("korgath", "immortality", GuildOptions.GetEverything);
        }

        [TestMethod]
        public void Get_Simple_Guild_Immortality_From_Korgath()
        {
            Assert.IsTrue(guild.Realm.Equals("korgath", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
            Assert.IsTrue(guild.Members.Any());
        }

        [TestMethod]
        public void Get_Valid_Night_Elf_Member_From_Immortality_Guild()
        {
            var guildMember = guild.Members.Where(m => m.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            Assert.IsTrue(guildMember.Character.Name.Equals("fleas", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(110, guildMember.Character.Level);
            Assert.AreEqual(CharacterClass.DRUID, guildMember.Character.@Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, guildMember.Character.Race);
            Assert.AreEqual(CharacterGender.MALE, guildMember.Character.Gender);
        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            Guild guild = explorer.GetGuild("laughing skull", "deus vox", GuildOptions.GetMembers | GuildOptions.GetAchievements);


            Assert.IsNotNull(guild.Members);
            Assert.IsNotNull(guild.AchievementPoints);

            Assert.IsTrue(guild.Name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guild.Realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guild.Members.Any());

            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Valid_Member_From_Horde_Guild()
        {
            Guild guild = explorer.GetGuild("skullcrusher", "rage", GuildOptions.GetMembers);

            Assert.IsNotNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Name.Equals("rage", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(guild.Members.Any());

            Assert.IsTrue(guild.Side == UnitSide.HORDE);
        }

        [TestMethod]
        public void Get_Guild_With_Only_Achievements()
        {
            Guild guild = explorer.GetGuild("skullcrusher", "immortality", GuildOptions.GetAchievements);


            Assert.IsNull(guild.Members);
            Assert.IsNotNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Only_Members()
        {
            Guild guild = explorer.GetGuild("skullcrusher", "immortality", GuildOptions.GetMembers);

            Assert.IsNotNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Only_No_Options()
        {
            var guild = explorer.GetGuild("skullcrusher", "immortality", GuildOptions.None);

            Assert.IsNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

        [TestMethod]
        public void Get_Guild_With_Base_Method_Call()
        {
            var guild = explorer.GetGuild("skullcrusher", "immortality");

            Assert.IsNull(guild.Members);
            Assert.IsNull(guild.Achievements);

            Assert.IsTrue(guild.Realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(UnitSide.ALLIANCE, guild.Side);
        }

    }
}
