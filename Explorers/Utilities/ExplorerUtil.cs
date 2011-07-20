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
    public static class ExplorerUtil
    {
        public const string host = "battle.net";

        public static string GetJSON(WebClient WebClient, string url)
        {
            return WebClient.DownloadString(url);
        }

        //JSON serialization - http://www.joe-stevens.com/2009/12/29/json-serialization-using-the-datacontractjsonserializer-and-c/
        public static T FromJSON<T>(string url) where T : class
        {
            WebClient WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;

            return FromJSON<T>(WebClient, url);
        }

        public static T FromJSON<T>(WebClient WebClient, string url) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(GetJSON(WebClient, url))))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

        public static string ToJSON<T>(T obj) where T : class
        {
            WebClient WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;

            return ToJSON<T>(WebClient, obj);
        }

        public static string ToJSON<T>(WebClient WebClient, T obj) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));

                DataContractJsonSerializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

    }
}
