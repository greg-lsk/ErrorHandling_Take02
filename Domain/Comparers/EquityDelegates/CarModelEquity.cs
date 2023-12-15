using Domain.Equality;
using Domain.ValueObjects;


namespace Domain.Comparers.EquityDelegates;

public static class CarModelEquity
{
    public static readonly HashDelegate<CarModel> ValueHash =
        c => HashCode.Combine(c.Name, ModelSpecificationEquity.ValueHash(c.Specifications));


    public static readonly EquityDelegate<CarModel> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.Name == right!.Name &&
               ModelSpecificationEquity.ByValue(left.Specifications, right.Specifications);
    };
}