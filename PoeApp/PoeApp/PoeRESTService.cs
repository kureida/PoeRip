using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace PoeApp
{
    public class PoeRESTService
    {
        readonly string uri = "http://api.pathofexile.com/ladders/Tempest?limit=20";

        public LadderData GetLadder()
        {


                using (WebClient webClient = new WebClient())
                {
                    return JsonConvert.DeserializeObject<LadderData>(webClient.DownloadString(uri));
                }
       
          
        }
        public LadderData GetLadder(int tom)
        {
            using (WebClient webClient = new WebClient())
            {
                string realTom = "&offset=" + tom;
                return JsonConvert.DeserializeObject<LadderData>(webClient.DownloadString("http://api.pathofexile.com/ladders/Tempest?limit=20" + realTom));
            }
        }

        public async Task<LadderData> GetLadderAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<LadderData>(await httpClient.GetStringAsync(uri));
            }
        }
    }
}