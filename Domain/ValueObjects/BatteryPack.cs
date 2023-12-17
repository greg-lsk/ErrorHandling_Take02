using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects;
public class BatteryPack(
    double capacity,
    bool holdsEssentialFuel,
    double chargeDuration)
    : EnergyTank(
        fuelType: FuelType.Electricity, 
        capacity, 
        needsManualRefill: true, 
        holdsEssentialFuel), IPlugable
{
    public double ChargeDuration { get; } = chargeDuration;
}