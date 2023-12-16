using Domain.Enums;

namespace Domain.ValueObjects.Abstractions;
public abstract class EnergyTank(double capacity)
{
    public abstract FuelType FuelType { get; }

    public double Capacity { get; } = capacity;
}