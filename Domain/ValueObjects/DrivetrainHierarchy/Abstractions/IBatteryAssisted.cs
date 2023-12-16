namespace Domain.ValueObjects.DrivetrainHierarchy.Abstractions;

internal interface IBatteryAssisted
{
    internal double BatteryCapacity { get; }
}