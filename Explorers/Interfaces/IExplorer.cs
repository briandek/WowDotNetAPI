﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Interfaces
{
    public interface IExplorer : IDisposable
    {
        WebClient WebClient { get; set; }
        JavaScriptSerializer JavaScriptSerializer { get; set; }

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

    }
}
