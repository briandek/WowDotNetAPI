using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace WowDotNetAPI.Utilities
{
    public static class ExplorerUtility
    {
        public static string GetBaseURL(Region region)
        {
            switch (region)
            {
                case Region.US:
                    return "https://us.battle.net";
                case Region.EU:
                    return "https://eu.battle.net";
                case Region.KR:
                    return "https://kr.battle.net";
                case Region.TW:
                    return "https://tw.battle.net";
                case Region.CN:
                    return "https://battlenet.com.cn";
                default:
                    return "https://us.battle.net";
            }
        }
    }
}
