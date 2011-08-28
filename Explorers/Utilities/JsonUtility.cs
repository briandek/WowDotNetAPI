using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using WowDotNetAPI.Exceptions;
using System.Security.Cryptography;

namespace WowDotNetAPI.Utilities
{
    public static class JsonUtility
    {

        public static string GetJSON(string url)
        {
            WebClient WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            WebClient.Proxy = null;

            return GetJSON(WebClient, url);
        }


        public static string GetJSON(WebClient WebClient, string url)
        {
            try
            {
                return WebClient.DownloadString(url);

            }
            catch (WebException wE)
            {
                using (HttpWebResponse eR = wE.Response as HttpWebResponse)
                using (MemoryStream stream = new MemoryStream())
                {
                    if (eR == null)
                    {
                        throw;
                    }

                    ErrorDetail newError = FromJSONStream<ErrorDetail>(new StreamReader(eR.GetResponseStream()));

                    switch (eR.StatusCode)
                    {
                        case HttpStatusCode.InternalServerError:    //500
                        case HttpStatusCode.NotFound:               //404
                        default:
                            throw new WowException(string.Format("Response Status: {0} {1}. {2}", (int)eR.StatusCode, eR.StatusCode, newError.Reason), newError, url);
                    }
                }
            }
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

        //TODO: Authentication WIP
        //public static T FromJSON<T>(WebClient WebClient, string url, string publicAuthKey, string privateAuthKey) where T : class
        //{
        //    string date = DateTime.Now.ToUniversalTime().ToString("r");

        //    string stringToSign = string.Format("GET\n{0}\n{1}\n"
        //        , date
        //        , WebClient.Headers["UrlPath"]);

        //    byte[] buffer = Encoding.UTF8.GetBytes(stringToSign);

        //    HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(privateAuthKey));

        //    string signature = Convert.ToBase64String(hmac.ComputeHash(buffer));

        //    WebClient.Headers[HttpRequestHeader.Authorization]
        //        = "BNET " + publicAuthKey + ":" + signature;

        //    return FromJSON<T>(WebClient, url);
        //}

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

        public static T FromJSONStream<T>(StreamReader sr) where T : class
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
            {
                DataContractJsonSerializer DataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
                return DataContractJsonSerializer.ReadObject(stream) as T;
            }
        }



    }
}
