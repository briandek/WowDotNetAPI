using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;

namespace WowDotNetAPI.Utilities
{
    public static class JsonUtility
    {
        public static string GetJSON(string url)
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            return GetJSON(req);
        }

        public static string GetJSON(HttpWebRequest req)
        {
            try
            {
                HttpWebResponse res = req.GetResponse() as HttpWebResponse;

                StreamReader streamReader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                return streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //JSON serialization - http://www.joe-stevens.com/2009/12/29/json-serialization-using-the-datacontractjsonserializer-and-c/
        public static T FromJSON<T>(string url) where T : class
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            return FromJSON<T>(req);
        }

        public static T FromJSON<T>(HttpWebRequest req) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(GetJSON(req))))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

        public static T FromJSON<T>(string url, string publicAuthKey, string privateAuthKey) where T : class
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            DateTime date = DateTime.Now.ToUniversalTime();
            req.Date = date;

            string stringToSign = 
                req.Method + "\n"
                + date.ToString("r") + "\n"
                + req.RequestUri.AbsolutePath + "\n";

            byte[] buffer = Encoding.UTF8.GetBytes(stringToSign);

            HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(privateAuthKey));

            string signature = Convert.ToBase64String(hmac.ComputeHash(buffer));
            
            req.Headers[HttpRequestHeader.Authorization]
                = "BNET " + publicAuthKey + ":" + signature;

            return FromJSON<T>(req);
        }

        public static string ToJSON<T>(T obj) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));

                DataContractJsonSerializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static T FromJSONStream<T>(StreamReader sr) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

        public static T FromJSONString<T>(string str) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }

    }
}
