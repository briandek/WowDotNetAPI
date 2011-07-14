WowDotNetAPI
=========
WowDotNetAPI is a C# .Net library for the World of Warcraft Community Platform API

THE LIBRARY IS STILL EVOLVING WITH THE PLATFORM API CHANGES. USE AT OWN RISK - AND JUMP IN, HACK AWAY AND HELP OUT :]

Currently supports access to the Realm, Guild, and Character(40%) areas of the Platform API.

You can now obtain the WowDotNetAPI dll through nuget. More information at [http://nuget.org/List/Packages/WowDotNetAPI](http://nuget.org/List/Packages/WowDotNetAPI)

Sample:
=========
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using WowDotNetAPI.Explorers;
	using WowDotNetAPI.Explorers.Extensions;
	using WowDotNetAPI.Explorers.Models;

	namespace WDA_Demo
	{
		class Program
		{
			static void Main(string[] args)
			{
				RealmExplorer rE = new RealmExplorer();
				CharacterExplorer cE = new CharacterExplorer();
				GuildExplorer gE = new GuildExplorer();

				Guild immortalityGuild = gE.GetGuild("skullcrusher", "immortality", true, true);

				Console.WriteLine("\n\nGUILD EXPLORER SAMPLE\n");

				//Prints
				//Immortality is a guild of level 25 and has 584 members.
				Console.WriteLine(string.Format("{0} is a guild of level {1} and has {2} members.", immortalityGuild.name, immortalityGuild.level, immortalityGuild.members.Count()));

				//Print out first top 50 ranked members of Immortality
				foreach (GuildMember member in immortalityGuild.members.OrderBy(m => m.rank).Take(50))
				{
					Console.WriteLine(member.character.name + " has rank " + member.rank);
				}

				//Still cleaning up the calls - bear with us :P
				//Get briandek and don't fetch any additional data but stats.
				//public Character GetCharacter(string region, string realm, string name,
				//bool getGuildInfo,
				//bool getStatsInfo,
				//bool getTalentsInfo,
				//bool getItemsInfo,
				//bool getReputationInfo,
				//bool getTitlesInfo,
				//bool getProfessionsInfo,
				//bool getAppearanceInfo,
				//bool getCompanionsInfo,
				//bool getMountsInfo,
				//bool getPetsInfo,
				//bool getAchievementsInfo,
				//bool getProgressionInfo)
				Console.WriteLine("\n\nCHARACTER EXPLORER SAMPLE\n");


				Character briandekCharacter =
					cE.GetCharacter("skullcrusher", "briandek", false, true, false, false, false, false, false, false, false, false, false, false, false);

				//Prints 
				//Briandek is a retired warrior of level 85 who has 6895 achievement points
				Console.WriteLine(string.Format("{0} is a retired warrior of level {1} who has {2} achievement points",
					briandekCharacter.name,
					briandekCharacter.level,
					briandekCharacter.achievementPoints));

				//Print out character stats
				//health : 174611
				//powerType : rage
				//power : 100
				//str : 3688
				//agi : 178
				//sta : 9399
				//int : 37
				//spr : 64
				//attackPower : 7611
				//rangedAttackPower : 253
				//mastery : 20.410751
				//masteryRating : 2225
				//...
				foreach (KeyValuePair<string, object> stat in briandekCharacter.stats)
				{
					Console.WriteLine(stat.Key + " : " + stat.Value);
				}

				//Fetch another character data with simple data 
				Character fleasCharacter = cE.GetCharacter("skullcrusher", "fleas");

				//Get one realm
				IEnumerable<Realm> usRealms = rE.GetRealms("us");
				Realm skullcrusher = usRealms.GetRealm("skullcrusher");


				//Get all pvp realms only
				IEnumerable<Realm> pvpRealmsOnly = usRealms.WithType("pvp");
				Console.WriteLine("\n\nREALMS EXPLORER SAMPLE\n");
				foreach (var realm in pvpRealmsOnly)
				{
					Console.WriteLine(string.Format("{0} has {1} population", realm.name, realm.population));
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