using Domain.Enums;

namespace Domain.ValueObjects.Abstractions;
public abstract class EnergyTank(
    FuelType fuelType,
    double capacity,
    bool needsManualRefill,
    bool holdsEssentialFuel)
{
    public FuelType FuelType { get; } = fuelType;

    public double Capacity { get; } = capacity;

    public bool NeedsManualRefill { get; } = needsManualRefill;
    public bool HoldsEssentialFuel { get; } = holdsEssentialFuel;
}