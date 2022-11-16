namespace CongestionTaxCalculator;
public interface IPriceService
{
    decimal GetPricePerHour(int hour, IList<DateTime> dateTimes);
}
