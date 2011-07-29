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
    public interface IExplorer : IDisposable
    {
        WebClient WebClient { get; set; }

        Character GetCharacter(string realm, string name);
        Character GetCharacter(string realm, string name, CharacterOptions characterOptions);

        Character GetCharacter(Region region, string realm, string name);
        Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions);

        Guild GetGuild(string realm, string name);
        Guild GetGuild(string realm, string name, GuildOptions guildOptions);

        Guild GetGuild(Region region, string realm, string name);
        Guild GetGuild(Region region, string realm, string name, GuildOptions guildOptions);

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

        void SetLocale(Locale locale);

    }
}
