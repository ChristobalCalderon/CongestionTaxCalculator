
namespace CongestionTaxCalculator;
public record GetTollFeeOutput(List<(DateTime, decimal)> Value, Notification Notification);