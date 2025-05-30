using System.Text.Json;

namespace GelisimTablosu.Utils
{
    public static class Helper
    {
        
    private const string ApiKey = "QO5k1VzpNtqY1m7zDcZBKsmBWMXqMDNn"; // Calendarific API anahtarınızı buraya ekleyin
    private const string BaseUrl = "https://calendarific.com/api/v2/holidays";

    public static async Task<List<string>> GetHolidaysAsync(int year, string country = "TR")
    {
        using var client = new HttpClient();
        var url = $"{BaseUrl}?&api_key={ApiKey}&country={country}&year={year}";
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(content);
        var holidays = new List<string>();

        var holidayArray = jsonDoc.RootElement.GetProperty("response").GetProperty("holidays").EnumerateArray();
        foreach (var holiday in holidayArray)
        {
            var date = holiday.GetProperty("date").GetProperty("iso").GetString();
            holidays.Add(date);
        }

        return holidays;
    }
        public static List<string> GetWeekdaysByWeekWithHolidays(DateTime startDate, DateTime endDate, List<string> holidays)
    {
        var weekRanges = new List<string>();
        var currentWeekStart = startDate.Date;
        var currentDate = startDate.Date;

        while (currentDate <= endDate)
        {
            if (currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate == endDate)
            {
                var weekEnd = currentDate.DayOfWeek == DayOfWeek.Sunday ? currentDate : currentDate.AddDays(-(int)currentDate.DayOfWeek);
                if (weekEnd < startDate) weekEnd = endDate;

                if (currentWeekStart <= weekEnd)
                {
                    // Haftanın çalışma günlerini kontrol et
                    var weekDays = new List<DateTime>();
                    for (var day = currentWeekStart; day <= weekEnd; day = day.AddDays(1))
                    {
                        if (day.DayOfWeek >= DayOfWeek.Monday && day.DayOfWeek <= DayOfWeek.Friday && !holidays.Contains(day.ToString("yyyy-MM-dd")))
                        {
                            weekDays.Add(day);
                        }
                    }

                    if (weekDays.Count > 0)
                    {
                        string weekRange = $"{weekDays[0]:dd.MM.yyyy} - {weekDays[weekDays.Count - 1]:dd.MM.yyyy}";
                        weekRanges.Add(weekRange);
                    }
                }

                currentWeekStart = currentDate.AddDays(1);
            }

            currentDate = currentDate.AddDays(1);
        }

        return weekRanges;
    }

        public static List<string> GetWeekdaysByWeek(DateTime startDate, DateTime endDate)
        {
            var weekRanges = new List<string>();
            var currentWeekStart = startDate.Date;
            var currentDate = startDate.Date;

            while (currentDate <= endDate)
            {
                // Haftanın son günü (Pazar) veya son tarih ise
                if (currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate == endDate)
                {
                    // Haftanın son gününü belirle
                    var weekEnd = currentDate.DayOfWeek == DayOfWeek.Sunday ? currentDate : currentDate.AddDays(-(int)currentDate.DayOfWeek);
                    if (weekEnd < startDate) weekEnd = endDate;

                    // Hafta içi gün varsa ekle
                    if (currentWeekStart <= weekEnd)
                    {
                        var cuma=weekEnd.AddDays(-2); // Cuma günü

                        string weekRange = $"{currentWeekStart:dd.MM.yyyy} - {cuma:dd.MM.yyyy}";
                        weekRanges.Add(weekRange);
                    }

                    // Bir sonraki haftanın başlangıcı
                    currentWeekStart = currentDate.AddDays(1);
                }

                currentDate = currentDate.AddDays(1);
            }

            return weekRanges;
        }
       
        // Ay bazında, her ayın haftalarını ve o haftaya ait çalışma günlerini (Pzt-Cuma) Dictionary olarak döndürür
        public static Dictionary<string, List<string>> GetWeekdaysByMonthWeeks(DateTime startDate, DateTime endDate)
        {
            var result = new Dictionary<string, List<string>>();
            var currentDate = startDate.Date;

            while (currentDate <= endDate)
            {
                // Haftanın başlangıcı (Pazartesi) ve sonu (Cuma) bulunur
                var weekStart = currentDate;
                if (weekStart.DayOfWeek != DayOfWeek.Monday)
                    weekStart = weekStart.AddDays(-(int)weekStart.DayOfWeek + (int)DayOfWeek.Monday);
                var weekEnd = weekStart.AddDays(4); // Cuma
                if (weekEnd > endDate) weekEnd = endDate;

                // Hafta günleri (Pzt-Cuma) listelenir
                var weekdays = new List<string>();
                for (var day = weekStart; day <= weekEnd; day = day.AddDays(1))
                {
                    if (day >= startDate && day <= endDate && day.DayOfWeek >= DayOfWeek.Monday && day.DayOfWeek <= DayOfWeek.Friday)
                    {
                        weekdays.Add(day.ToString("yyyy-MM-dd"));
                    }
                }

                if (weekdays.Count > 0)
                {
                    // Ay adı ve yıl anahtar olarak kullanılır
                    string monthKey = weekStart.ToString("MMMM yyyy");
                    string weekRange = $"{weekStart:dd.MM.yyyy} - {weekEnd:dd.MM.yyyy}";
                    if (!result.ContainsKey(monthKey))
                        result[monthKey] = new List<string>();
                    result[monthKey].Add(weekRange);
                }

                // Sonraki haftaya geç
                currentDate = weekEnd.AddDays(3); // Cumartesiden sonraki Pazartesi
            }
            return result;
        }
    }
}