using Domain.Equality;
using Domain.Entities;


namespace Domain.Comparers.EquityDelegates;

public static class CarInventoryEquity
{
    public static HashDelegate<CarInventory> IdHash => BaseEntityEquity.IdHash;
    public static EquityDelegate<CarInventory> ById => BaseEntityEquity.ById;

    
    public static readonly HashDelegate<CarInventory> ValueHash =
        c => HashCode.Combine(c.Id,
                              c.AvailableUnits,
                              CarEquity.ValueHash(c.Car));


    public static readonly EquityDelegate<CarInventory> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.AvailableUnits == right!.AvailableUnits &&
               BaseEntityEquity.ByValue(left, right) &&
               CarEquity.ByValue(left.Car, right.Car);
    };
}