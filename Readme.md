WowDotNet
=========
WowDotNetAPI is a C# .Net library for the World of Warcraft Community Platform API

You can now obtain the WowDotNetAPI dll through nuget. More information at [http://nuget.org/List/Packages/WowDotNetAPI](http://nuget.org/List/Packages/WowDotNetAPI)

Instructions
============

After referencing the WowDotNetAPI.dll in your solution, you should be able to create a RealmExplorer object.

	RealmExplorer usRealmExplorer = new RealmExplorer()	    //the default region is set to "US"

	RealmExplorer euRealmExplorer = new RealmExplorer("eu") //or if you want to look at European realms

	RealmExplorer krRealmExplorer = new RealmExplorer()		//or Korean
	krRealmExplorer.region = "kr"

The RealmAPI uses a Realm object as its base data model 

	//Realm API simple doc reference. Author: Cyaga - http://us.battle.net/wow/en/forum/topic/2416192911
    //Realm 
    //name: string, the fully formatted name of the realm
    //slug: string, "data-friendly" version of name, punctuation removed and spaces converted to dashes
    //type: string, type of the realm: pve, pvp, rp, rppvp
    //status: boolean, true if realm is up, false otherwise
    //queue: boolean, true if realm has a queue, false otherwise
    //population: string, the realm's population: low, medium, high

	public class Realm
		{
		  public string name { get; set; }
		  public string slug { get; set; }
		  public string type { get; set; }
          public bool status { get; set; }
          public bool queue { get; set; }
          public string population { get; set; }
		}

The RealmExplorer returns lists of these objects or returns a json string depending on what function we use and what query we send to the community platform api.

The RealmAPI relies on Json.Net for all of the JSON serialization and related operations.

Sample Use :
----------------------

	var usRE = new RealmExplorer();
	var realmList = usRE.GetAllRealms();						//Returns list of All US realms	
	var singleRealm = usRE.GetSingleRealm("Aegwynn")			//Returns Realm object Aewynn data
	
	var twoFavoriteRealms = usRE.GetMultipleRealms("Skullcrusher", "Laughing Skull");   //Returns list of the 2 Realm objects
		
	var pvpOnlyRealmList = usRE.GetAllRealmsByType("pvp");							//Returns list of All US pvp realms
	var medPopulationRealmJson = usRE.GetRealmsByPopulationAsJson("medium");		//Returns json of medium populated realms

	//Sample API url http://us.battle.net/api/wow/realm/status?realm=Medivh&realm=Blackrock

	var sampleAPIRealmList = usRE.GetMultipleRealmsViaQuery("?realm=Medivh&realm=Blackrock");						
	var anotherSampleAPIRealmList = usRE.GetMultipleRealms("Medivh", "Blackrock");   
	var sampleAPIJson = usRE.GetMultipleRealmsViaQueryAsJson("?realm=Medivh&realm=Blackrock");		
 


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