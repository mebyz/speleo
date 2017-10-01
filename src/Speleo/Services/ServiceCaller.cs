using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Speleo.Services
{
    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public static class ServiceCaller
    {

        private const int TIME_OUT = 3; // 3 secondes
        /// <summary>
        /// Call externe - Generic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T Get<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.Timeout = new TimeSpan(0, 0, 0 , TIME_OUT, 0);
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;
                        if (responseString == null)
                            return default(T);
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return default(T);
                }
                return default(T);
            }
        }

        /// <summary>
        /// Call externe and get String
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.Timeout = new TimeSpan(0, 0, 0, TIME_OUT, 0);
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;                       
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
                return null;
            }
        }

    }
}
