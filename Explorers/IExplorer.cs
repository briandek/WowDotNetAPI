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
    public interface IExplorer
    {
        Character GetCharacter(string realm, string name);
        Character GetCharacter(string realm, string name, CharacterOptions characterOptions);

        Character GetCharacter(Region region, string realm, string name);
        Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions);

        Guild GetGuild(string realm, string name);
        Guild GetGuild(string realm, string name, GuildOptions guildOptions);

        Guild GetGuild(Region region, string realm, string name);
        Guild GetGuild(Region region, string realm, string name, GuildOptions guildOptions);

        AchievementInfo GetAchievement(int id);

        IEnumerable<AchievementList> GetAchievements();
        IEnumerable<AchievementList> GetGuildAchievements();

        IEnumerable<BattlegroupInfo> GetBattlegroupsData();

        IEnumerable<ItemClassInfo> GetItemClasses();

        IEnumerable<Realm> GetRealms();

        Auctions GetAuctions(string realm);

        Item GetItem(int id);

        IEnumerable<CharacterRaceInfo> GetCharacterRaces();

        IEnumerable<CharacterClassInfo> GetCharacterClasses();

        IEnumerable<GuildRewardInfo> GetGuildRewards();

        IEnumerable<GuildPerkInfo> GetGuildPerks();

        Challenges GetChallenges(string realm);

        Leaderboard GetLeaderBoards(Bracket bracket);

    }
}
