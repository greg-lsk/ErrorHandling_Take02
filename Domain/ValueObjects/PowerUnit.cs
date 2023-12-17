using Domain.Enums;
using Domain.Interfaces;

namespace Domain.ValueObjects;

public class PowerUnit(
    PowerUnitRole role,
    FuelTank[] tanks,
    double? powerOutput,
    double? efficiency,
    double? emissions,
    double? range)
{
    public PowerUnitRole Role { get; } = role;

    public FuelTank[] Tanks { get; } = tanks;

    public double? PowerOutput { get; } = powerOutput;

    public double? Emissions { get; } = emissions;
    public double? Efficiency { get; } = efficiency;

    public double? Range { get; } = range;


    public bool NeedsCharging() => Tanks.Any(t => t is IPlugable);

    public bool CanBePoweredBy(FuelType fuelType) => Tanks.Any(t => t.FuelType == fuelType);
    public bool CanOnlyBePoweredBy(FuelType fuelType) => Tanks.All(t => t.FuelType == fuelType);

}