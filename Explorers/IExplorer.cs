﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WowDotNetAPI.Models;
using System.Runtime.Serialization.Json;
using WowDotNetAPI.Utilities;
using WowDotNetAPI.Exceptions;

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

        IEnumerable<BattlegroupInfo> GetBattlegroups();

        IEnumerable<ItemClassInfo> GetItemClasses();

        IEnumerable<Realm> GetRealms();
        IEnumerable<Realm> GetRealms(Region region);

        Auctions GetAuctions(string realm);

        Item GetItem(string id);

        IEnumerable<CharacterRaceInfo> GetCharacterRaces();
        IEnumerable<CharacterRaceInfo> GetCharacterRaces(Region region);

        IEnumerable<CharacterClassInfo> GetCharacterClasses();
        IEnumerable<CharacterClassInfo> GetCharacterClasses(Region region);

        IEnumerable<GuildRewardInfo> GetGuildRewards();
        IEnumerable<GuildRewardInfo> GetGuildRewards(Region region);

        IEnumerable<GuildPerkInfo> GetGuildPerks();
        IEnumerable<GuildPerkInfo> GetGuildPerks(Region region);

        void SetLocale(Locale locale);

    }
}
