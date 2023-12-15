using Domain.Entities;
using Domain.Equality.Delegates;


namespace Domain.Equality;

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

    public static readonly EqualityComparer<CarInventory> IdComparer = Equity.Comparer(ById, IdHash);


    public static readonly HashDelegate<CarInventory> ValueHash =
        c => HashCode.Combine(c.Id, CarEquity.ValueHash(c.Car));

    public static readonly EquityDelegate<CarInventory> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.AvailableUnits == right!.AvailableUnits &&
               CarEquity.ByValue(left.Car, right.Car);
    };

    public static readonly EqualityComparer<CarInventory> ValueComparer = Equity.Comparer(ByValue, ValueHash);
}