
namespace CongestionTaxCalculator;
public record GetTollFeeInput(VehicleType VechicleType, IList<DateTime> DateTimes, Notification Notification)
{
    public void Validate()
    {
        if (!this.VechicleType.IsValidVechicleType())
        {
            Notification.Add(nameof(this.VechicleType), $"{nameof(this.VechicleType)} is not a valid vechicle.");
        }

        if (this.VechicleType.IsTaxExemptVehicles())
        {
            Notification.Add(nameof(this.VechicleType), $"{this.VechicleType.ToString()} is tax exempted.");
        }

        if (this.DateTimes == null || this.DateTimes.Count < 1)
        {
            Notification.Add(nameof(this.DateTimes), $"{nameof(this.DateTimes)} is required.");
        }
    }
}
