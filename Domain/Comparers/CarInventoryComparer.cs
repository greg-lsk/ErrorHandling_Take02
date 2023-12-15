using Domain.Entities;
using Domain.Equality;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public class CarInventoryComparer
{
    public static EqualityComparer<CarInventory> ForId => 
        Equity.Comparer(CarInventoryEquity.ById,
                        CarInventoryEquity.IdHash);

    public static EqualityComparer<CarInventory> ForValue => 
        Equity.Comparer(CarInventoryEquity.ByValue,
                        CarInventoryEquity.ValueHash);
}