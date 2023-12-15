using Domain.Equality;
using Domain.ValueObjects;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public class UtilitySpecsComparer
{
    public static EqualityComparer<UtilitySpecs> ForValue =>
        Equity.Comparer(UtilitySpecsEquity.ByValue,
                        UtilitySpecsEquity.ValueHash);
}