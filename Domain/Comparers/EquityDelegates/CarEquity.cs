using Domain.Equality;
using Domain.Entities;


namespace Domain.Comparers.EquityDelegates;

public static class CarEquity
{
    public static readonly HashDelegate<Car> IdHash =
        c => HashCode.Combine(c.Id);


    public static readonly EquityDelegate<Car> ById =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.Id == right!.Id;
    };


    public static readonly HashDelegate<Car> ValueHash =
        c => HashCode.Combine(c.Id, CarModelEquity.ValueHash(c.Model));


    public static readonly EquityDelegate<Car> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.Id == right!.Id &&
               CarModelEquity.ByValue(left.Model, right.Model);
    };
}