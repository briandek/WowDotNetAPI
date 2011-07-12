using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.CharacterExplorerModels;
using System.Web.Script.Serialization;

namespace WowDotNetAPI.Explorers.Extensions
{
    public static class CharacterExtension
    {
        public static string ToJson(this Character character, JavaScriptSerializer JavascriptSerializer)
        {
            return JavascriptSerializer.Serialize(character);
        }
    }
}
