using CongestionTaxCalculator;
using CongestionTaxCalculator.Infrastructure;

Console.WriteLine("Congestion tax rules in Gothenburg");
Console.WriteLine("Scoped to only work for year 2013");

/// 
/// Prepare use case
///

IPriceService priceService = new PriceService();

GetTollFee useCase = new(priceService);

/// 
/// Prepare input
/// 

VehicleType vechicleType = new(7); //Combi

List<DateTime> list = new()
{
    new DateTime(2013, 01, 14, 21, 00, 00),
    new DateTime(2013, 01, 15, 21, 00, 00),
    new DateTime(2013, 02, 07, 06, 23, 27),
    new DateTime(2013, 02, 07, 15, 27, 00),
    new DateTime(2013, 02, 08, 06, 27, 00),
    new DateTime(2013, 02, 08, 06, 20, 00),
    new DateTime(2013, 02, 08, 14, 35, 00),
    new DateTime(2013, 02, 08, 15, 29, 00),
    new DateTime(2013, 02, 08, 15, 47, 00),
    new DateTime(2013, 02, 08, 16, 01, 00),
    new DateTime(2013, 02, 08, 16, 48, 00),
    new DateTime(2013, 02, 08, 17, 49, 00),
    new DateTime(2013, 02, 08, 18, 29, 00),
    new DateTime(2013, 02, 08, 18, 35, 00),
    new DateTime(2013, 03, 26, 14, 25, 00),
    new DateTime(2013, 03, 28, 14, 07, 27),
};

var notification = new Notification();

GetTollFeeInput input = new(vechicleType, list, notification);

/// 
/// Execute use case
/// 

var output = useCase.Execute(input);


///
/// Act if any notifications
///

if (output != null && output.Notification.IsInvalid)
{
    foreach (var item in output.Notification.ModelState)
    {
        Console.WriteLine($"Key: {item.Key} Value: {item.Value}");

    }
}

///
/// Print result
///

Console.WriteLine($"Total Fee: { output.TotalFee }");

