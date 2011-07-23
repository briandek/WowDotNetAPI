WowDotNetAPI
=========
WowDotNetAPI is a C# .Net library for the World of Warcraft Community Platform API

THE LIBRARY IS STILL EVOLVING WITH THE PLATFORM API CHANGES. USE AT OWN RISK - AND JUMP IN, HACK AWAY AND HELP OUT :]

Currently supports access to the Realm, Guild, and Character areas of the Platform API.

You can now obtain the WowDotNetAPI dll through nuget. More information at [http://nuget.org/List/Packages/WowDotNetAPI](http://nuget.org/List/Packages/WowDotNetAPI)

Sample:
=========
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using WowDotNetAPI;
	using WowDotNetAPI.Extensions;
	using WowDotNetAPI.Models;

	namespace WDA_Demo
	{
		class Program
		{
			static void Main(string[] args)
			{
				WowExplorer explorer = new WowExplorer(Region.US);

				Guild immortalityGuild = explorer.GetGuild("skullcrusher", "immortality", true, true);

				Console.WriteLine("\n\nGUILD EXPLORER SAMPLE\n");

				Console.WriteLine("{0} is a guild of level {1} and has {2} members.",
					immortalityGuild.Name,
					immortalityGuild.Level,
					immortalityGuild.Members.Count());

				//Print out first top 20 ranked members of Immortality
				foreach (GuildMember member in immortalityGuild.Members.OrderBy(m => m.Rank).Take(20))
				{
					Console.WriteLine(member.Character.Name + " has rank " + member.Rank);
				}

				Console.WriteLine("\n\nCHARACTER EXPLORER SAMPLE\n");
				Character briandekCharacter =
					explorer.GetCharacter("skullcrusher", "briandek", false, true, false, false, false, false, false, false, false, false, false, false, false);

				Console.WriteLine("{0} is a retired warrior of level {1} who has {2} achievement points",
					briandekCharacter.Name,
					briandekCharacter.Level,
					briandekCharacter.AchievementPoints);

				foreach (KeyValuePair<string, object> stat in briandekCharacter.Stats)
				{
					Console.WriteLine(stat.Key + " : " + stat.Value);
				}

				//Get one realm
				IEnumerable<Realm> usRealms = explorer.GetRealms(Region.US);
				Realm skullcrusher = usRealms.GetRealm("skullcrusher");

				//Get all pvp realms only
				IEnumerable<Realm> pvpRealmsOnly = usRealms.WithType(RealmType.PVP);
				Console.WriteLine("\n\nREALMS EXPLORER SAMPLE\n");
				foreach (var realm in pvpRealmsOnly)
				{
					Console.WriteLine("{0} has {1} population", realm.Name, realm.Population);
				}

				Console.WriteLine("\n\nGUILD PERKS\n");

				IEnumerable<GuildPerkInfo> perks = explorer.GetGuildPerks();
				foreach (var perk in perks)
				{
					Console.WriteLine("{0} perk at guild level {1}", perk.Spell.Name, perk.GuildLevel);
				}

				Console.WriteLine("\n\nGUILD REWARDS\n");

				IEnumerable<GuildRewardInfo> rewards = explorer.GetGuildRewards();
				foreach (var reward in rewards)
				{
					Console.WriteLine("{0} reward at min guild level {1}", reward.Item.Name, reward.MinGuildLevel);
				}

				Console.WriteLine("\n\nCHARACTER RACES\n");

				IEnumerable<CharacterRaceInfo> races = explorer.GetCharacterRaces();
				foreach (var race in races.OrderBy(r =>r.Id))
				{
					Console.WriteLine("{0} race with numeric value {1}", race.Name, race.Id);
				}

				Console.WriteLine("\n\nCHARACTER CLASSES\n");

				IEnumerable<CharacterClassInfo> classes = explorer.GetCharacterClasses();
				foreach (var @class in classes.OrderBy(c => c.Id))
				{
					Console.WriteLine("{0} class with numeric value {1}", @class.Name, @class.Id);
				}
			}
		}
	}





Contributing
============
 
Please feel free to jump in and contribute to the project.  
Just fork the project, commit your changes (preferably to a new branch), and then send me a pull request via GitHub. 
Please add tests for your feature or fix.
 

 
License
=======
 
WowDotNetAPI is released under the MIT license.
 
    Copyright (c) 2011 Briam Ramos
 
    Permission is hereby granted, free of charge, to any person
    obtaining a copy of this software and associated documentation
    files (the "Software"), to deal in the Software without
    restriction, including without limitation the rights to use,
    copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the
    Software is furnished to do so, subject to the following
    conditions:
 
    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.
 
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    OTHER DEALINGS IN THE SOFTWARE.