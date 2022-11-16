namespace CongestionTaxCalculator;
using CongestionTaxCalculator.Infrastructure;

public class GetTollFee
{
    public IPriceService PriceService { get; }

    private const decimal MaxFeePerDay = 60m;
    private const int July = 07;

    public GetTollFee(
        IPriceService priceService)
    {
        PriceService = priceService;
    }

    public GetTollFeeOutput Execute(GetTollFeeInput input)
    {
        input.Validate();

        if (input.Notification.IsInvalid)
        {
            return new GetTollFeeOutput(new(), input.Notification);
        }

        var datesToChargeTax = input
            .DateTimes
            .Where(date =>
                !date.IsPublicHoliday() &&
                !date.AddDays(1).IsPublicHoliday() &&
                date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday &&
                date.Month != July).ToList();

        var groupedByDays = datesToChargeTax
            .GroupBy(
                dateTime =>
                dateTime.Date.Day)
            .ToList();

        List<(DateTime, decimal)> feeOnDay = new();

        foreach (var day in groupedByDays)
        {
            var groupedByHour = day
                .GroupBy(x => x.Hour)
                .ToList();

            Decimal fee = 0;

            foreach (var hours in groupedByHour)
            {
                fee += this.PriceService.GetPricePerHour(hours.Key, hours.ToArray());
            }

            var maxFeePerDay = Math.Min(fee, MaxFeePerDay);

            var date = day.First();

            var whichDay = new DateTime(date.Year, date.Month, day.Key);
            feeOnDay.Add((whichDay, maxFeePerDay));
        }

        return new GetTollFeeOutput(feeOnDay, input.Notification);
    }
}
