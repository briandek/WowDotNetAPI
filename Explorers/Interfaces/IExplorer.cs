﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WowDotNetAPI.Models;
using System.Runtime.Serialization.Json;

namespace WowDotNetAPI.Interfaces
{
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

        Character GetCharacter(string region, string realm, string name);
        Character GetCharacter(string region, string realm, string name,
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
        
        Guild GetGuild(string region, string realm, string name);
        Guild GetGuild(string region, string realm, string name, 
            bool getMembers, 
            bool getAchievements);

        IEnumerable<Realm> GetRealms();
        IEnumerable<Realm> GetRealms(string region);

        IEnumerable<CharacterRace> GetCharacterRaces();
        IEnumerable<CharacterRace> GetCharacterRaces(string region);

        IEnumerable<CharacterClass> GetCharacterClasses();
        IEnumerable<CharacterClass> GetCharacterClasses(string region);

        IEnumerable<GuildReward> GetGuildRewards();
        IEnumerable<GuildReward> GetGuildRewards(string region);

        IEnumerable<GuildPerk> GetGuildPerks();
        IEnumerable<GuildPerk> GetGuildPerks(string region);

    }
}
