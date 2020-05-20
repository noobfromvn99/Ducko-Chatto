using Newtonsoft.Json;
using RandomChat.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomChat.Models
{

    public class LocationManger
    {
        private HttpClient client;
        private readonly static LocationManger _instance = new LocationManger();
        private const string ACCESSKEY = APIStrings.IPSTACK_ACESSKEY;

        private LocationManger()
        {
            client = LocationApi.InitializeClient();
        }

        public static LocationManger GetInstance()
        {
            return _instance;
        }

        public async Task<Location> GetLocation(string IP)
        {
            if (IP == null)
                return null;
            Console.WriteLine(IP);
            var response = await client.GetAsync($"{IP}?access_key={ACCESSKEY}");
            if (!response.IsSuccessStatusCode)
                throw new ItemNotFoundExcpetion("Status Failed");

            var result = response.Content.ReadAsStringAsync().Result;
            var location = JsonConvert.DeserializeObject<Location>(result);

            return location;

        }
    }
}
