using Domain.Enums;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;


namespace Domain.ValueObjects.DrivetrainHierarchy;

public sealed class ElectricDrivetrain(
    int odometerReading,
    double chargingDuration,
    int bateryRange,
    double batteryCapacity,
    double energyEfficiency) 
    : Drivetrain(
        odometerReading, 
        emissions:0, 
        Transmission.Automatic), IBatteryPowered, IPlugable
{
    public override PowerSource PowerSource => PowerSource.Electric;

    public int BatteryRange { get; init; } = bateryRange;
    public double BatteryCapacity { get; } = batteryCapacity;
    public double EnergyEfficiency { get; } = energyEfficiency;

    public double ChargingDuration { get; init; } = chargingDuration;
}