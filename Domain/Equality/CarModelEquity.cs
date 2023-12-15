using Domain.ValueObjects;
using Domain.Equality.Delegates;


namespace Domain.Equality;

public static class CarModelEquity
{
    public static readonly HashDelegate<CarModel> ValueHash =
        c => HashCode.Combine(c.Name, ModelSpecificationEquity.ValueHash(c.Specifications));


    public static readonly EquityDelegate<CarModel> ByValue =
    (left, right) =>
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return left.Name == right.Name &&
               ModelSpecificationEquity.ByValue(left.Specifications, right.Specifications);
    };
}