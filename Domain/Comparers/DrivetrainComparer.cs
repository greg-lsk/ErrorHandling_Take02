using Domain.Equality;
using Domain.ValueObjects;
using Domain.Comparers.EquityDelegates;


namespace Domain.Comparers;

public class DrivetrainComparer
{
    public static EqualityComparer<Drivetrain> ForValue =>
        Equity.Comparer(DrivetrainEquity.ByValue, DrivetrainEquity.ValueHash);
}