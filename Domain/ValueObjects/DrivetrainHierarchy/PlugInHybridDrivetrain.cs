using Domain.Enums;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;

namespace Domain.ValueObjects.DrivetrainHierarchy;

public class PlugInHybridDrivetrain(
    int odometerReading,
    double emissions,
    Transmission transmission,
    int fuelRange,
    FuelType fuelType,
    double fuelTankCapacity,
    double fuelEfficiency,
    double batteryCapacity,
    int batteryRange,
    double energyEfficiency,
    double chargingDuration)
    : HybridDrivetrain(
        odometerReading,
        emissions,
        transmission,
        fuelRange,
        fuelType,
        fuelTankCapacity,
        fuelEfficiency,
        batteryCapacity), IBatteryPowered, IPlugable
{
    public int BatteryRange { get; } = batteryRange;
    public double EnergyEfficiency { get; } = energyEfficiency;

    public double ChargingDuration { get; } = chargingDuration;
}