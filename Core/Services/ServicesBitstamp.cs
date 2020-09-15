using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BitcoinLogger.Core.Models;

namespace BitcoinLogger.Core.Services {

public class ServicesBitstamp : IServices, IDisposable

    {
        static HttpClient client = new HttpClient ();

        public async Task<ILiveData> GetBitcoinPrice (string uri) 
        {
            try  
            {            
                var response = await client.GetAsync (uri);
                if (response.IsSuccessStatusCode) 
                {
                    var result = await response.Content.ReadAsStringAsync ();
                    return JsonConvert.DeserializeObject<LiveDataBitstamp> (result);
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