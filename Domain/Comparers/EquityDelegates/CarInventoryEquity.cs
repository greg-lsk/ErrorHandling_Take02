using Domain.Equality;
using Domain.Entities;


namespace Domain.Comparers.EquityDelegates;

public static class CarInventoryEquity
{
    public static readonly HashDelegate<CarInventory> IdHash =
        c => HashCode.Combine(c.Id);

    public static readonly EquityDelegate<CarInventory> ById =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.Id == right!.Id;
    };

    
    public static readonly HashDelegate<CarInventory> ValueHash =
        c => HashCode.Combine(c.Id, CarEquity.ValueHash(c.Car));

    public static readonly EquityDelegate<CarInventory> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.AvailableUnits == right!.AvailableUnits &&
               CarEquity.ByValue(left.Car, right.Car);
    };
}