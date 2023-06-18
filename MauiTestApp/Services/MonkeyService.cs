using MauiTestApp.Models;
using System.Net.Http.Json;

namespace MauiTestApp.Services
{
    public class MonkeyService
    {
        HttpClient _httpClient;

        public MonkeyService()
        {
            _httpClient = new HttpClient();
        }

        List<Monkey> monkeyList = new();

        public async Task<List<Monkey>> GetMonkeys()
        {
            var response = await _httpClient.GetAsync("https://www.montemagno.com/monkeys.json");

            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
            }

            if (monkeyList?.Count > 0)
                return monkeyList;

            return monkeyList;
        }
    }
}
