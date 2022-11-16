namespace CongestionTaxCalculator.Infrastructure;

public class PriceService : IPriceService
{
    public decimal GetPricePerHour(int hour, IList<DateTime> dateTimes)
    {
        var maxFeeOfHour = 0.0m;

        foreach (var dateTime in dateTimes)
        {
            if (FeePerHour.TryGetValue(hour, out var feePerHour))
            {
                var fee = feePerHour(dateTime.TimeOfDay);
                maxFeeOfHour = Math.Max(fee, maxFeeOfHour);
            }
        }

        return maxFeeOfHour;
    }

    private static Dictionary<int, Func<TimeSpan, Decimal>> FeePerHour
        => new()
        {
            {
                06,
                (arg1) =>
                {
                    TimeSpan start = new TimeSpan(06, 00, 0);
                    TimeSpan end = new TimeSpan(06, 30, 0);

                    if ((arg1 >= start) && (arg1 < end))
                    {
                        return 8;
                    }
                    else
                    {
                        return 18;
                    }
                }
            },
            {
                07,
                (arg1) =>
                {
                    return 18;
                }
            },
            {
                08,
                (arg1) =>
                {
                    TimeSpan start = new TimeSpan(08, 00, 0);
                    TimeSpan end = new TimeSpan(08, 30, 0);

                    if ((arg1 >= start) && (arg1 < end))
                    {
                        return 13;
                    }
                    else
                    {
                        return 8;
                    }
                }
            },
            {
                09,
                (arg1) =>
                {
                    return 8;
                }
            },
            {
                10,
                (arg1) =>
                {
                    return 8;
                }
            },
            {
                11,
                (arg1) =>
                {
                    return 8;
                }
            },
            {
                12,
                (arg1) =>
                {
                    return 8;
                }
            },
            {
                13,
                (arg1) =>
                {
                    return 8;
                }
            },
            {
                14,
                (arg1) =>
                {
                    return 8;
                }
            },
            {
                15,
                (arg1) =>
                {
                    TimeSpan start = new TimeSpan(15, 00, 0);
                    TimeSpan end = new TimeSpan(15, 30, 0);

                    if ((arg1 >= start) && (arg1 < end))
                    {
                        return 13;
                    }
                    else
                    {
                        return 18;
                    }
                }
            },
            {
                16,
                (arg1) =>
                {
                    return 18;
                }
            },
            {
                17,
                (arg1) =>
                {
                    return 13;
                }
            },
            {
                18,
                (arg1) =>
                {
                    TimeSpan start = new TimeSpan(18, 00, 0);
                    TimeSpan end = new TimeSpan(18, 30, 0);

                    if ((arg1 >= start) && (arg1 < end))
                    {
                        return 8;
                    }
                    else
                    {
                        return 0;
                    }
                }
            },
            {
                21,
                (arg1) =>
                {
                    return 8;
                }
            },
        };
}

public class FeeInHour
{
    public decimal GetFee(int minute)
    {
        return 0.0m;
    }
}
