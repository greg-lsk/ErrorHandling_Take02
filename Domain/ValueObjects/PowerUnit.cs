using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects;
public class PowerUnit(
    PowerUnitRole role,
    FuelTank[] primaryTanks,
    FuelTank[]? assistiveTanks = null,
    double? powerOutput = null,
    double? efficiency = null,
    double? emissions = null,
    double? range = null)
{
    public PowerUnitRole Role { get; } = role;

    public EnergyTank[] PrimaryTanks { get; } = primaryTanks;
    public EnergyTank[]? AssistiveTanks { get; } = assistiveTanks;

    public double? PowerOutput { get; } = powerOutput;

    public double? Emissions { get; } = emissions;
    public double? Efficiency { get; } = efficiency;

    public double? Range { get; } = range;


    public bool IsActivelyRefilled() =>
        PrimaryTanks.All(t => !t.NeedsManualRefill) &&
        (AssistiveTanks?.All(t => !t.NeedsManualRefill) ?? true);

    public IEnumerable<FuelType> RefillableWith() =>
        PrimaryTanks
        .Where(t => t.NeedsManualRefill)
        .Select(t => t.FuelType)
        .Concat(AssistiveTanks?
            .Where(t => t.NeedsManualRefill)
            .Select(t => t.FuelType) 
            ?? Array.Empty<FuelType>())
        .Distinct();

    public bool NeedsRefuellingWith(FuelType fuelType) =>
        PrimaryTanks.Any(t => t.NeedsManualRefill && t.FuelType == fuelType);
}