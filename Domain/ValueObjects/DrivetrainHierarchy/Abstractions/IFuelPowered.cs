using Domain.Enums;

namespace Domain.ValueObjects.DrivetrainHierarchy.Abstractions;

internal interface IFuelPowered
{
    internal int FuelRange { get; }

    internal FuelType FuelType { get; }
    internal double FuelTankCapacity { get; }

    internal double FuelEfficiency { get; }
}