using Domain.Entities;
using Domain.Equality;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public class CarComparer
{
    public static EqualityComparer<Car> ForId =>
        Equity.Comparer(CarEquity.ById, CarEquity.IdHash);

    public static EqualityComparer<Car> ForValue =>
        Equity.Comparer(CarEquity.ByValue, CarEquity.ValueHash);
}