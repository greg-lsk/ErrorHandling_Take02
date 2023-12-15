using Domain.Equality;
using Domain.Entities.Abstractions;


namespace Domain.Comparers.EquityDelegates;

public class BaseEntityEquity
{
    public static readonly Hash<BaseEntity> IdHash =
        b => HashCode.Combine(b.Id);


    public static readonly Equity<BaseEntity> ById =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.Id == right!.Id;
    };

    public static Hash<BaseEntity> ValueHash => IdHash;
    public static Equity<BaseEntity> ByValue => ById;
}