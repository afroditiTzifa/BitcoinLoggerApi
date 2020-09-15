using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BitcoinLogger.Core.Models;

namespace BitcoinLogger.Core.Services {

public class ServicesGDAX : IServices, IDisposable

    {
        static HttpClient client = new HttpClient ();

        public async Task<ILiveData> GetBitcoinPrice (string uri) 
        {
            try 
            {    
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Framework Test Client");                
                var response = await client.GetAsync (uri);
                if (response.IsSuccessStatusCode) 
                {
                    string result = await response.Content.ReadAsStringAsync ();
                    return JsonConvert.DeserializeObject<LiveDataGDAX> (result);
                }
                return null;

            } catch (Exception ex) 
            {
                Console.Write(ex.Message);
                return null;
                //2do 
            }
        }

        public void Dispose () {
            client.Dispose ();
        }

    }
}