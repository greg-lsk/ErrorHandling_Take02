using Domain.Equality;
using Domain.ValueObjects;


namespace Domain.Comparers.EquityDelegates;

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
        if (Equity.Inferred(left, right)) return true;

        return left!.NumberOfSeats == right!.NumberOfSeats &&
               left.NumberOfDoors == right.NumberOfSeats &&
               left.BootCapacity == right.BootCapacity &&
               DrivetrainEquity.ByValue(left.Drivetrain, right.Drivetrain);
    };
}