using Domain.Equality;
using Domain.Comparers.EquityDelegates;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;


namespace Domain.Comparers;

public class DrivetrainComparer
{
    public static EqualityComparer<Drivetrain> ForValue =>
        Equity.Comparer(DrivetrainEquity.ByValue, DrivetrainEquity.ValueHash);
}