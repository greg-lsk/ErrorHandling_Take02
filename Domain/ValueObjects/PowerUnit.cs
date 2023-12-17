using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects.Abstractions;

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

    public EnergyTank[] Tanks { get; } = tanks;

    public double? PowerOutput { get; } = powerOutput;

    public double? Emissions { get; } = emissions;
    public double? Efficiency { get; } = efficiency;

    public double? Range { get; } = range;


    public bool NeedsCharging() => Tanks.Any(t => t is IPlugable);

    public IEnumerable<FuelType> EssentialFuelTypes() => Tanks.Where(t => t.HoldsEssentialFuel)
                                                              .Select(t => t.FuelType);


}