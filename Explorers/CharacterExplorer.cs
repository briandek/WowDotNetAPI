using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Interfaces;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Models;
using WowDotNetAPI.Explorers.Utilities;

namespace WowDotNetAPI.Explorers
{
    public class CharacterExplorer : ICharacterExplorer
    {

        private const string baseRealmAPIurl =
            "http://{0}." + ExplorerUtil.host + CharacterUtil.basePath + "/{1}/{2}?fields=";

        public WebClient WebClient { get; set; }
        public JavaScriptSerializer JavaScriptSerializer { get; set; }

        public string Region { get; set; }
        public string Realm { get; set; }
        public string Name { get; set; }

        public Character Character { get; private set; }

        public CharacterExplorer() : this("us") { }
        public CharacterExplorer(string region)
        {
            JavaScriptSerializer = new JavaScriptSerializer();
            WebClient = new WebClient();
            Region = region;
        }

        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter("us", realm, name);
        }

        public Character GetCharacter(string region, string realm, string name)
        {
            Character = GetData(string.Format(baseRealmAPIurl, Region, realm, name));
            return Character;
        }

        private Character GetData(string url)
        {
            var characterJsonObject = (Dictionary<string, object>)JavaScriptSerializer.DeserializeObject(ExplorerUtil.GetJson(WebClient, url));
            return JavaScriptSerializer.ConvertToType<Character>(characterJsonObject);
        }

        public void Refresh()
        {
            Character = GetData(string.Format(baseRealmAPIurl, Region, Realm, Name));

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
