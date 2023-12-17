using Domain.Enums;
using Domain.ValueObjects.Abstractions;

namespace Domain.ValueObjects;
public class FuelTank(
    FuelType fuelType,
    double capacity,
    bool holdsEssentialFuel,
    bool needsManualRefill) 
    : EnergyTank(fuelType, capacity, needsManualRefill, holdsEssentialFuel) { }