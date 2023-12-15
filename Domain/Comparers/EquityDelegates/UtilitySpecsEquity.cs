using Domain.Equality;
using Domain.ValueObjects;


namespace Domain.Comparers.EquityDelegates;

public static class UtilitySpecsEquity
{
    public static readonly Hash<UtilitySpecs> ValueHash =
    m => HashCode.Combine(m.NumberOfSeats,
                          m.NumberOfDoors,
                          m.BootCapacity);

    public static readonly Equity<UtilitySpecs> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.NumberOfSeats == right!.NumberOfSeats &&
               left.NumberOfDoors == right.NumberOfDoors &&
               left.BootCapacity == right.BootCapacity;
    };
}