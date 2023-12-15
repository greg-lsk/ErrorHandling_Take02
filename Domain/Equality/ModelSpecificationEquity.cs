using Domain.ValueObjects;
using Domain.Equality.Delegates;


namespace Domain.Equality;

public static class ModelSpecificationEquity
{
    public static readonly HashDelegate<ModelSpecifications> ValueHash =
    m => HashCode.Combine(m.NumberOfSeats,
                          m.NumberOfDoors,
                          m.BootCapacity,
                          DrivetrainEquity.ValueHash(m.Drivetrain));

    public static readonly EquityDelegate<ModelSpecifications> ByValue =
    (left, right) =>
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return left.NumberOfSeats == right.NumberOfSeats &&
               left.NumberOfDoors == right.NumberOfSeats &&
               left.BootCapacity == right.BootCapacity &&
               DrivetrainEquity.ByValue(left.Drivetrain, right.Drivetrain);
    };
}