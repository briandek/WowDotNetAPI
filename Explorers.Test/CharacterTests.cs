using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;
using WowDotNetAPI.Explorers.Test;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class CharacterTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;
        private const Region WowRegion = Region.EU;
        private const Locale WowLocale = Locale.en_GB;
        private const string CharacterName = "Eadie";
        private const string Realm = "Burning Blade";
        private const int level = 100;
        private const CharacterClass cClass = CharacterClass.MAGE;
        private const CharacterRace cRace = CharacterRace.GOBLIN;
        private const CharacterGender cGender = CharacterGender.MALE;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(WowRegion, WowLocale, APIKey);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithGuild()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetGuild);

            Assert.IsNotNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithStats()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetStats);

            Assert.IsNull(briandek.Guild);
            Assert.IsNotNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithTalents()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetTalents);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNotNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithItems()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetItems);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNotNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithReputations()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetReputation);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNotNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithTitles()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetTitles);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNotNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithProfessions()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetProfessions);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNotNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithAppearance()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetAppearance);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNotNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithPetSlots()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetPetSlots);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNotNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
            Assert.IsTrue(briandek.PetSlots.Count() > 0);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithMounts()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetMounts);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
            Assert.IsTrue(briandek.Mounts.NumCollected > 1);
            Assert.IsTrue(briandek.Mounts.NumNotCollected > 1);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithAchievements()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetAchievements);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithProgression()
        {

            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetProgression);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }

        [TestMethod]
        public void Get_Complex_Character_Briandek_From_Skullcrusher()
        {
            var briandek = explorer.GetCharacter(Realm, CharacterName, CharacterOptions.GetEverything);

            Assert.IsNotNull(briandek.Guild);
            Assert.IsNotNull(briandek.Stats);
            Assert.IsNotNull(briandek.Talents);
            Assert.IsNotNull(briandek.Items);
            Assert.IsNotNull(briandek.Reputation);
            Assert.IsNotNull(briandek.Titles);
            Assert.IsNotNull(briandek.Professions);
            Assert.IsNotNull(briandek.Appearance);
            Assert.IsNotNull(briandek.PetSlots);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNotNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals(CharacterName, StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(level, briandek.Level);
            Assert.AreEqual(cClass, briandek.@Class);
            Assert.AreEqual(cRace, briandek.Race);
            Assert.AreEqual(cGender, briandek.Gender);
        }       
    }
}
