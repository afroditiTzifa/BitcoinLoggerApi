using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BitcoinLogger.Core.Models;

namespace BitcoinLogger.Core.Services {

public class BitcoinLoggerServicesGDAX : IBitcoinLoggerServices, IDisposable

    {
        static HttpClient client = new HttpClient ();

        public async Task<IBitcoinPriceDTO> GetBitcoinPrice (string uri) {
            
            

            IBitcoinPriceDTO responseObj =null;
            responseObj = new BitcoinPriceGDAX();
           
            try {
                
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Framework Test Client");                
                HttpResponseMessage response = await client.GetAsync (uri);
 
                if (response.IsSuccessStatusCode) {
                    string result = await response.Content.ReadAsStringAsync ();
                   
                    responseObj = JsonConvert.DeserializeObject<BitcoinPriceGDAX> (result);

                }

            } catch (Exception ex) 
            {
                Console.Write(ex.Message);
                //2do 
            }
            return responseObj;
        }

        public void Dispose () {
            client.Dispose ();
        }

    }
}