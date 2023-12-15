using Domain.Equality;
using Domain.ValueObjects;


namespace Domain.Comparers.EquityDelegates;

public static class UtillitySpecsEquity
{
    public static readonly Hash<UtillitySpecs> ValueHash =
    m => HashCode.Combine(m.NumberOfSeats,
                          m.NumberOfDoors,
                          m.BootCapacity);

    public static readonly Equity<UtillitySpecs> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left.NumberOfSeats == right.NumberOfSeats &&
               left.NumberOfDoors == right.NumberOfSeats &&
               left.BootCapacity == right.BootCapacity;
    };
}