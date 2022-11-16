namespace CongestionTaxCalculator;
public readonly record struct VehicleType(int Id)
{
    public override string ToString()
    => this.Names[this.Id];

    public bool IsValidVechicleType()
        => Names.ContainsKey(this.Id);

    public bool IsTaxExemptVehicles()
        => this.Id == Emergency ||
           this.Id == Bus ||
           this.Id == Diplomat ||
           this.Id == Motorcycles ||
           this.Id == Military ||
           this.Id == Foreign; 

    private Dictionary<int, string> Names
        => new()
        {
            { Emergency, "Emergency vehicles" },
            { Bus, "Busses" },
            { Diplomat, "Diplomat vehicles" },
            { Motorcycles, "Motorcycles" },
            { Military, "Military vehicles" },
            { Foreign, "Foreign vehicles" },
            { Combi, "Combi vehicles" },
            { Truck, "Truck vehicles" },
        };

    private static int Emergency
        => 1;

    private static int Bus
        => 2;

    private static int Diplomat
        => 3;

    private static int Motorcycles
        => 4;

    private static int Military
    => 5;

    private static int Foreign
    => 6;

    private static int Combi
    => 7;

    private static int Truck
    => 8;
}
