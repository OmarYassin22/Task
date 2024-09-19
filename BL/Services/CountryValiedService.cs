using BL.Interfaces;
using System.Net;

namespace PAL.Services
{
    public class CountryValiedService : ICountryValidService
    {
        private readonly HttpClient _httpClient;

        public CountryValiedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> IsVaild(string countryName)
        {
            var response = await _httpClient.GetAsync($"https://api.countrylayer.com/v2/name/{countryName}?access_key=a86c98b48ff2b2ff57ec9cb818d2d05f&fullText=true");
            Console.WriteLine(response.StatusCode);
            Console.WriteLine("============================");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
