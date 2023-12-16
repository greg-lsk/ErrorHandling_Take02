using Domain.Enums;
using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects;
public class FuelTank(double capacity, FuelType fuelType) : EnergyTank(capacity)
{
    public override FuelType FuelType { get; } = fuelType;
}