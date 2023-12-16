using Domain.Enums;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;


namespace Domain.ValueObjects.DrivetrainHierarchy;

public class TraditionalDrivetrain(
    int odometerReading,
    double emissions,
    Transmission transmission,
    int fuelRange,
    FuelType fuelType,
    double fuelTankCapacity,
    double fuelEfficiency) : Drivetrain(odometerReading, emissions, transmission), IFuelPowered
{
    public override PowerSource PowerSource => PowerSource.InternalCombustion;

    public int FuelRange { get; init; } = fuelRange;
    public FuelType FuelType { get; init; } = fuelType;
    public double FuelEfficiency { get; init; } = fuelEfficiency;
    public double FuelTankCapacity { get; init; } = fuelTankCapacity;
}