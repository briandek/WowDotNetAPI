using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WowDotNetAPI
{
    public enum Region
    {
        US,     //us.api.battle.net/
        EU,     //eu.api.battle.net/
        KR,     //kr.api.battle.net/
        TW,     //tw.api.battle.net/
        CN,     // ???
        SEA     //sea.api.battle.net/
    }

    public enum Locale
    {
        None,
        //US
        en_US,
        es_MX,
        pt_BR,
        //EU
        en_GB,
        de_DE,
        es_ES,
        fr_FR,
        it_IT,
        pl_PL,
        pt_PT,
        ru_RU,
        //KR
        ko_KR,
        //TW
        zh_TW,
        //CN
        zh_CN
    }

    [Flags]
    public enum CharacterOptions
    {
        None = 0,
        GetGuild = 1,
        GetStats = 2,
        GetTalents = 4,
        GetItems = 8,
        GetReputation = 16,
        GetTitles = 32,
        GetProfessions = 64,
        GetAppearance = 128,
        GetPetSlots = 256,
        GetMounts = 512,
        GetPets = 1024,
        GetAchievements = 2048,
        GetProgression = 4096,
        GetFeed = 8192,
        GetPvP = 16384,
        GetQuests = 32768,
        GetHunterPets = 65536,
        GetEverything = GetGuild | GetStats | GetTalents | GetItems | GetReputation | GetTitles
        | GetProfessions | GetAppearance | GetPetSlots | GetMounts | GetPets
        | GetAchievements | GetProgression | GetFeed | GetPvP | GetQuests | GetHunterPets
    }

    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetNews = 4,
        GetEverything = GetMembers | GetAchievements | GetNews
    }

    public class WowExplorer : IExplorer
    {
        public Region Region { get; set; }
        public Locale Locale { get; set; }
        public string APIKey { get; set; }

        public string Host { get; set; }

        public WowExplorer(Region region, Locale locale, string apiKey)
        {
            Region = region;
            Locale = locale;
            APIKey = apiKey;

            switch (Region)
            {
                case Region.EU:
                    Host = "https://eu.api.battle.net";
                    break;
                case Region.KR:
                    Host = "https://kr.api.battle.net";
                    break;
                case Region.TW:
                    Host = "https://tw.api.battle.net";
                    break;
                case Region.CN:
                    Host = "https://www.battlenet.com.cn";
                    break;
                case Region.US:
                default:
                    Host = "https://us.api.battle.net";
                    break;
            }
        }

        #region Character

        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter(Region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(Region region, string realm, string name)
        {
            return GetCharacter(region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            return GetCharacter(Region, realm, name, characterOptions);
        }

        public Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            Character character;

            TryGetData<Character>(
                string.Format(@"{0}/wow/character/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, Locale, CharacterUtility.buildOptionalQuery(characterOptions), APIKey),
                out character);

            return character;
        }

        #endregion

        #region Guild

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuild(Region, realm, name, realmOptions);
        }

        public Guild GetGuild(Region region, string realm, string name, GuildOptions realmOptions)
        {
            Guild guild;

            TryGetData<Guild>(
                string.Format(@"{0}/wow/guild/{1}/{2}?locale={3}{4}&apikey={5}", Host, realm, name, Locale, GuildUtility.buildOptionalQuery(realmOptions), APIKey),
                out guild);

            return guild;
        }

        #endregion

        #region Pets

        /// <summary>
        /// Gets a list of all battle pets
        /// </summary>
        /// <returns>PetList object containing an IEnumerable of Pet objects</returns>
        public IEnumerable<Pet> GetPets()
        {
            PetList pets;

            TryGetData<PetList>(string.Format(@"{0}/wow/pet/?locale={1}&apikey={2}", Host, Locale, APIKey),
                out pets);

            return pets.Pets;
        }

        /// <summary>
        /// Gets details on a specific Battle Pet ability
        /// </summary>
        /// <param name="id">The id of the ability to get details on.</param>
        /// <returns>Returns PetAbilityDetails object for the ability with the given id</returns>
        public PetAbilityDetails GetPetAbilityDetails(int id)
        {
            PetAbilityDetails ability;

            TryGetData<PetAbilityDetails>(string.Format(@"{0}/wow/pet/ability/{1}?locale={2}&apikey={3}", Host, id, Locale, APIKey),
                out ability);

            return ability;
        }

        /// <summary>
        /// Gets details on a specific [species of] Battle Pet
        /// </summary>
        /// <param name="id">The species ID of the battle pet</param>
        /// <returns>PetSpecies object containing details for the battle pet with the given species ID</returns>
        public PetSpecies GetPetSpeciesDetails(int id)
        {
            PetSpecies species;

            TryGetData<PetSpecies>(string.Format(@"{0}/wow/pet/species/{1}?locale={2}&apikey={3}", Host, id, Locale, APIKey),
                out species);

            return species;
        }

        /// <summary>
        /// Retrieve detailed information about a given species of pet.
        /// </summary>
        /// <param name="speciesId">The pet's species ID. This can be found by querying a users' list of pets via the Character Profile API.</param>
        /// <param name="level">The pet's level. Pet levels max out at 25. If omitted the API assumes a default value of 1.</param>
        /// <param name="breedId">The pet's breed. Retrievable via the Character Profile API. If omitted the API assumes a default value of 3.</param>
        /// <param name="qualityId">The pet's quality. Retrievable via the Character Profile API. Pet quality can range from 0 to 5 (0 is poor quality and 5 is legendary). If omitted the API will assume a default value of 1.</param>
        /// <returns></returns>
        public PetStats GetPetStats(int speciesId, int level, int breedId, int qualityId)
        {
            PetStats stats;

            TryGetData<PetStats>(string.Format(@"{0}/wow/pet/stats/{1}?level={2}&breedId={3}&qualityId={4}&locale={5}&apikey={6}", Host, speciesId, level, breedId, qualityId, Locale, APIKey),
                out stats);

            return stats;
        }

        /// <summary>
        /// The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PetType> GetPetTypes()
        {
            PetTypeData types;

            TryGetData<PetTypeData>(string.Format(@"{0}/wow/data/pet/types?locale={1}&apikey={2}", Host, Locale, APIKey),
                out types);

            return types.PetTypes.Any() ? types.PetTypes : null;
        }

        #endregion

        #region Mounts

        public IEnumerable<Mount> GetMounts()
        {
            Mounts mounts;

            TryGetData<Mounts>(string.Format(@"{0}/wow/mount/?locale={1}&apikey={2}", Host, Locale, APIKey),
                out mounts);

            return mounts.MountList;
        }

        #endregion

        #region Realms
        public IEnumerable<Realm> GetRealms(Locale locale)
        {
            RealmsData realmsData;
            TryGetData<RealmsData>(
                string.Format(@"{0}/wow/realm/status?locale={1}&apikey={2}", Host, Locale, APIKey),
                out realmsData);
            if (realmsData == null)
            {
                return null;
            }
            return locale == Locale.None ? realmsData.Realms : realmsData.Realms.Where(x => x.Locale == locale.ToString());
        }

        public IEnumerable<Realm> GetRealms()
        {
            return this.GetRealms(Locale.None);
        }

        #endregion

        #region Auctions
        /// <summary>
        /// Gets a list of all current auctions on the given realm and connected realms
        /// </summary>
        /// <param name="realm">The name of the realm to base the search on</param>
        /// <returns>Auctions object for the given realm.</returns>
        public Auctions GetAuctions(string realm)
        {
            AuctionFiles auctionFiles;

            TryGetData<AuctionFiles>(
                string.Format(@"{0}/wow/auction/data/{1}?locale={2}&apikey={3}", Host, realm.ToLower().Replace(' ', '-'), Locale, APIKey),
                out auctionFiles);

            if (auctionFiles != null)
            {
                string url = "";
                foreach (AuctionFile auctionFile in auctionFiles.Files)
                {
                    url = auctionFile.URL;
                }

                Auctions auctions;

                TryGetData<Auctions>(url, out auctions);

                return auctions;
            }

            return null;
        }

        #endregion

        #region Items
        public Item GetItem(int id)
        {
            Item item;

            TryGetData<Item>(
                string.Format(@"{0}/wow/item/{1}?locale={2}&apikey={3}", Host, id, Locale, APIKey),
                out item);

            return item;
        }

        public IEnumerable<ItemClassInfo> GetItemClasses()
        {
            ItemClassData itemclassdata;

            TryGetData<ItemClassData>(
                string.Format(@"{0}/wow/data/item/classes?locale={1}&apikey={2}", Host, Locale, APIKey),
                out itemclassdata);

            return (itemclassdata != null) ? itemclassdata.Classes : null;
        }

        #endregion

        #region CharacterRaceInfo
        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            CharacterRacesData charRacesData;

            TryGetData<CharacterRacesData>(
                string.Format(@"{0}/wow/data/character/races?locale={1}&apikey={2}", Host, Locale, APIKey),
                out charRacesData);

            return (charRacesData != null) ? charRacesData.Races : null;
        }
        #endregion

        #region CharacterClassInfo
        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            CharacterClassesData characterClasses;

            TryGetData<CharacterClassesData>(
                string.Format(@"{0}/wow/data/character/classes?locale={1}&apikey={2}", Host, Locale, APIKey),
                out characterClasses);

            return (characterClasses != null) ? characterClasses.Classes : null;
        }
        #endregion

        #region GuildRewardInfo
        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            GuildRewardsData guildRewardsData;

            TryGetData<GuildRewardsData>(
                string.Format(@"{0}/wow/data/guild/rewards?locale={1}&apikey={2}", Host, Locale, APIKey),
                out guildRewardsData);

            return (guildRewardsData != null) ? guildRewardsData.Rewards : null;
        }
        #endregion

        #region GuildPerkInfo
        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            GuildPerksData guildPerksData;

            TryGetData<GuildPerksData>(
                 string.Format(@"{0}/wow/data/guild/perks?locale={1}&apikey={2}", Host, Locale, APIKey),
                 out guildPerksData);

            return (guildPerksData != null) ? guildPerksData.Perks : null;
        }
        #endregion

        #region Achievements
        /// <summary>
        /// Gets details on a particular achievement
        /// </summary>
        /// <param name="id">The id of the achievement to get details on</param>
        /// <returns>AchievementInfo object for the achievement with the given id</returns>
        public AchievementInfo GetAchievement(int id)
        {
            AchievementInfo achievement;

            TryGetData<AchievementInfo>(
                string.Format(@"{0}/wow/achievement/{1}?locale={2}&apikey={3}", Host, id, Locale, APIKey),
                out achievement);

            return achievement;
        }

        /// <summary>
        /// Gets a list of all character achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetAchievements()
        {
            AchievementData achievementData;

            TryGetData<AchievementData>(
                string.Format(@"{0}/wow/data/character/achievements?locale={1}&apikey={2}", Host, Locale, APIKey),
                out achievementData);

            return (achievementData != null) ? achievementData.Lists : null;
        }

        /// <summary>
        /// Gets a list of all guild achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetGuildAchievements()
        {
            AchievementData achievementData;

            TryGetData<AchievementData>(
                string.Format(@"{0}/wow/data/guild/achievements?locale={1}&apikey={2}", Host, Locale, APIKey),
                out achievementData);

            return (achievementData != null) ? achievementData.Lists : null;
        }

        #endregion

        #region Battlegroups
        public IEnumerable<BattlegroupInfo> GetBattlegroupsData()
        {
            BattlegroupData battlegroupData;

            TryGetData<BattlegroupData>(
                string.Format(@"{0}/wow/data/battlegroups/?locale={1}&apikey={2}", Host, Locale, APIKey),
                out battlegroupData);

            return (battlegroupData != null) ? battlegroupData.Battlegroups : null;
        }
        #endregion

        #region Challenges

        /// <summary>
        /// The data in this request has data for all 9 challenge mode maps (currently). The map field includes the current medal times for each dungeon. Inside each ladder we provide data about each character that was part of each run. The character data includes the current cached spec of the character while the member field includes the spec of the character during the challenge mode run.
        /// </summary>
        /// <param name="realm">The realm being requested.</param>
        /// <returns></returns>
        public Challenges GetChallenges(string realm)
        {
            Challenges challenges;

            TryGetData<Challenges>(
                string.Format(@"{0}/wow/challenge/{1}?locale={2}&apikey={3}", Host, realm, Locale, APIKey),
                out challenges);

            return challenges;
        }
        #endregion

        #region Quests

        /// <summary>
        /// Retrieve metadata for a given quest.
        /// </summary>
        /// <param name="questId">The ID of the desired quest.</param>
        /// <returns></returns>
        public Quest GetQuestData(int questId)
        {
            Quest quest;

            TryGetData<Quest>(
                string.Format(@"{0}/wow/quest/{1}?locale={2}&apikey={3}", Host, questId, Locale, APIKey),
                out quest);

            return quest;
        }

        #endregion

        #region PvP
        public Leaderboard GetLeaderBoards(Bracket bracket)
        {
            Leaderboard pvpRows;

            TryGetData<Leaderboard>(
                string.Format(@"{0}/wow/leaderboard/{1}?locale={2}&apikey={3}", Host, bracket.ToString().Replace("_", "") , Locale, APIKey),
                out pvpRows);

            return pvpRows;
        }
        #endregion

        #region Recipes

        /// <summary>
        /// The recipe API provides basic recipe information.
        /// </summary>
        /// <param name="recipeId">Unique ID for the desired recipe.</param>
        /// <returns></returns>
        public Recipe GetRecipeData(int recipeId)
        {
            Recipe recipe;

            TryGetData<Recipe>(
                string.Format(@"{0}/wow/recipe/{1}?locale={2}&apikey={3}", Host, recipeId, Locale, APIKey),
                out recipe);

            return recipe;
        }

        #endregion

        #region Spells

        /// <summary>
        /// The spell API provides some information about spells.
        /// </summary>
        /// <param name="spellId">Unique ID of the desired spell.</param>
        /// <returns></returns>
        public Spell GetSpellData(int spellId)
        {
            Spell spell;

            TryGetData<Spell>(
                string.Format(@"{0}/wow/spell/{1}?locale={2}&apikey={3}", Host, spellId, Locale, APIKey),
                out spell);

            return spell;
        }

        #endregion

        private T GetData<T>(string url) where T : class
        {
            return JsonUtility.FromJSON<T>(url);
        }

        private void TryGetData<T>(string url, out T requestedObject) where T : class
        {
            try
            {
                requestedObject = JsonUtility.FromJSON<T>(url);
            }
            catch (Exception ex)
            {
                requestedObject = null;
                throw ex;
            }
        }
    }
}
