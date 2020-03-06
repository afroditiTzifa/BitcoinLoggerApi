using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BitcoinLogger.Core.Models;

namespace BitcoinLogger.Core.Services {

public class BitcoinLoggerServicesBitmap : IBitcoinLoggerServices, IDisposable

    {
        static HttpClient client = new HttpClient ();

        public async Task<IBitcoinPriceDTO> GetBitcoinPrice (string uri) {
            
            

            IBitcoinPriceDTO responseObj =null;
            responseObj = new BitcoinPriceBitstamp();
           
            try {
                         
                HttpResponseMessage response = await client.GetAsync (uri);
 
                if (response.IsSuccessStatusCode) {
                    string result = await response.Content.ReadAsStringAsync ();
                    
                    responseObj = JsonConvert.DeserializeObject<BitcoinPriceBitstamp> (result);
                   

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