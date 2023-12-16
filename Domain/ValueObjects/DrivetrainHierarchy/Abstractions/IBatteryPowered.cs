namespace Domain.ValueObjects.DrivetrainHierarchy.Abstractions;

internal interface IBatteryPowered
{
    internal int BatteryRange { get; }

    internal double BatteryCapacity { get; }

    internal double EnergyEfficiency { get; }
}