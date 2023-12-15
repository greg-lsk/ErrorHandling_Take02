using Domain.Equality;
using Domain.Entities.Abstractions;


namespace Domain.Comparers.EquityDelegates;

public class BaseEntityEquity
{
    public static readonly HashDelegate<BaseEntity> IdHash =
        b => HashCode.Combine(b.Id);


    public static readonly EquityDelegate<BaseEntity> ById =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.Id == right!.Id;
    };

    public static HashDelegate<BaseEntity> ValueHash => IdHash;
    public static EquityDelegate<BaseEntity> ByValue => ById;
}