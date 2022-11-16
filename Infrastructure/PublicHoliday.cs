namespace CongestionTaxCalculator.Infrastructure;
public static class PublicHolidayExtension
{
    public static bool IsPublicHoliday(this DateTime date)
    {
        if(Holidays.TryGetValue(date.Month, out var holiday))
        {
            return holiday != null && holiday.Contains(date.Day);
        }

        return false;
    }

    private static Dictionary<int, int[]> Holidays
    => new()
    {
        {
            01,
            new[] { 1 }
        },
        {
            02,
            new[] { 14 }
        },
        {
            03,
            new[] { 20, 29, 30, 31 }
        },
        {
            04,
            new[] { 1, 30 }
        },
        {
            05,
            new[] { 1, 9, 18, 19, 26 }
        },
        {
            06,
            new[] { 6, 21, 22 }
        },
        {
            09,
            new[] { 22, 27 }
        },
        {
            10,
            new[] { 27 }
        },
        {
            11,
            new[] { 1, 2, 10 }
        },
        {
            12,
            new[] { 1, 8, 15, 21, 22, 24, 25, 26, 31 }
        },
    };
}
