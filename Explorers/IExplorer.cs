﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WowDotNetAPI.Models;
using System.Runtime.Serialization.Json;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI
{
    public enum Region
    {
        US,
        EU,
        KR,
        TW
    }

    public enum CharacterOption
    {
        GetGuild,
        GetStats,
        GetTalents,
        GetItems,
        GetReputation,
        GetTitles,
        GetProfessions,
        GetAppearance,
        GetCompanions,
        GetMounts,
        GetPets,
        GetAchievements,
        GetProgression
    }

    public interface IExplorer : IDisposable
    {
        WebClient WebClient { get; set; }

        Character GetCharacter(string realm, string name);
        Character GetCharacter(string realm, string name,
            bool getGuildInfo,
            bool getStatsInfo,
            bool getTalentsInfo,
            bool getItemsInfo,
            bool getReputationInfo,
            bool getTitlesInfo,
            bool getProfessionsInfo,
            bool getAppearanceInfo,
            bool getCompanionsInfo,
            bool getMountsInfo,
            bool getPetsInfo,
            bool getAchievementsInfo,
            bool getProgressionInfo);

        Character GetCharacter(Region region, string realm, string name);
        Character GetCharacter(Region region, string realm, string name,
            bool getGuildInfo,
            bool getStatsInfo,
            bool getTalentsInfo,
            bool getItemsInfo,
            bool getReputationInfo,
            bool getTitlesInfo,
            bool getProfessionsInfo,
            bool getAppearanceInfo,
            bool getCompanionsInfo,
            bool getMountsInfo,
            bool getPetsInfo,
            bool getAchievementsInfo,
            bool getProgressionInfo);


        Guild GetGuild(string realm, string name);
        Guild GetGuild(string realm, string name, 
            bool getMembers, 
            bool getAchievements);

        Guild GetGuild(Region region, string realm, string name);
        Guild GetGuild(Region region, string realm, string name, 
            bool getMembers, 
            bool getAchievements);

        IEnumerable<Realm> GetRealms();
        IEnumerable<Realm> GetRealms(Region region);

        IEnumerable<CharacterRaceInfo> GetCharacterRaces();
        IEnumerable<CharacterRaceInfo> GetCharacterRaces(Region region);

        IEnumerable<CharacterClassInfo> GetCharacterClasses();
        IEnumerable<CharacterClassInfo> GetCharacterClasses(Region region);

        IEnumerable<GuildRewardInfo> GetGuildRewards();
        IEnumerable<GuildRewardInfo> GetGuildRewards(Region region);

        IEnumerable<GuildPerkInfo> GetGuildPerks();
        IEnumerable<GuildPerkInfo> GetGuildPerks(Region region);

    }
}
