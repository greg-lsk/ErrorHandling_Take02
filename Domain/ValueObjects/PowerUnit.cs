using Domain.Enums;

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
}