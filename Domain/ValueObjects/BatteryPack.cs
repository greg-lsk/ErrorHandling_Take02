using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects;
public class BatteryPack(double capacity) : EnergyTank(capacity), IPlugable
{
    public override FuelType FuelType => FuelType.Electricity;

    public double ChargeDuration { get; }
}