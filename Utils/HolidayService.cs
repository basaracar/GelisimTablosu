using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace GelisimTablosu.Utils
{
    public class HolidayService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public HolidayService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Calendarific:ApiKey"];
            _baseUrl = "https://calendarific.com/api/v2/holidays";
        }

        public async Task<List<string>> GetHolidaysAsync(int year, string country = "TR")
        {
            var url = $"{_baseUrl}?&api_key={_apiKey}&country={country}&year={year}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            using var jsonDoc = JsonDocument.Parse(content);

            var holidays = new List<string>();
            var holidayArray = jsonDoc.RootElement
                .GetProperty("response")
                .GetProperty("holidays")
                .EnumerateArray();

            foreach (var holiday in holidayArray)
            {
                var date = holiday.GetProperty("date").GetProperty("iso").GetString();
                holidays.Add(date);
            }

            return holidays;
        }
    }
}