using Domain.Equality;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;


namespace Domain.Comparers.EquityDelegates;

public static class DrivetrainEquity
{
    public static readonly Hash<Drivetrain> ValueHash =
        (d) => HashCode.Combine(d.PowerSource, d.Transmission);

    public static readonly Equity<Drivetrain> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.PowerSource == right!.PowerSource &&
               left.Transmission == right.Transmission;
    };
}