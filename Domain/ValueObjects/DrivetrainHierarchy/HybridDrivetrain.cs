using Domain.Enums;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;


namespace Domain.ValueObjects.DrivetrainHierarchy;

public class HybridDrivetrain(
    int odometerReading,
    double emissions,
    Transmission transmission,
    int fuelRange,
    FuelType fuelType,
    double fuelTankCapacity,
    double fuelEfficiency,
    double batteryCapacity) 
    : TraditionalDrivetrain(
        odometerReading,
        emissions,
        transmission,
        fuelRange,
        fuelType,
        fuelTankCapacity,
        fuelEfficiency), IBatteryAssisted
{
    public double BatteryCapacity { get; } = batteryCapacity;
}