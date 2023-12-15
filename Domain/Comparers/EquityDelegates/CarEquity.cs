using Domain.Equality;
using Domain.Entities;


namespace Domain.Comparers.EquityDelegates;

public static class CarEquity
{
    public static HashDelegate<Car> IdHash => BaseEntityEquity.IdHash;
    public static EquityDelegate<Car> ById => BaseEntityEquity.ById;


    public static readonly HashDelegate<Car> ValueHash =
        c => HashCode.Combine(c.Id, CarModelEquity.ValueHash(c.Model));


    public static readonly EquityDelegate<Car> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return BaseEntityEquity.ByValue(left, right) &&
               CarModelEquity.ByValue(left!.Model, right!.Model);
    };
}