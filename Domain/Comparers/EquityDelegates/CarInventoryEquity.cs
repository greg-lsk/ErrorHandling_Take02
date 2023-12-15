using Domain.Equality;
using Domain.Entities;


namespace Domain.Comparers.EquityDelegates;

public static class CarInventoryEquity
{
    public static Hash<CarInventory> IdHash => BaseEntityEquity.IdHash;
    public static Equity<CarInventory> ById => BaseEntityEquity.ById;

    
    public static readonly Hash<CarInventory> ValueHash =
        c => HashCode.Combine(c.Id,
                              c.AvailableUnits,
                              CarEquity.ValueHash(c.Car));


    public static readonly Equity<CarInventory> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.AvailableUnits == right!.AvailableUnits &&
               BaseEntityEquity.ByValue(left, right) &&
               CarEquity.ByValue(left.Car, right.Car);
    };
}