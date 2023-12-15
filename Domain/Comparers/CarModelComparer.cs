using Domain.Equality;
using Domain.ValueObjects;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public  class CarModelComparer
{
    public static EqualityComparer<CarModel> ForValue =>
        Equity.Comparer(CarModelEquity.ByValue,
                        CarModelEquity.ValueHash);
}