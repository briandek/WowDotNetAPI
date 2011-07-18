using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Models;
using System.Web.Script.Serialization;

namespace WowDotNetAPI.Extensions
{
    public static class GuildExtension
    {
        public static string ToJson(this Guild guild, JavaScriptSerializer JavascriptSerializer)
        {
            return JavascriptSerializer.Serialize(guild);
        }
    }
}
