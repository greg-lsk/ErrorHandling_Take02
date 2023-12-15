using Domain.Equality;
using Domain.ValueObjects;


namespace Domain.Comparers.EquityDelegates;

public static class DrivetrainEquity
{
    public static readonly HashDelegate<Drivetrain> ValueHash =
        (d) => HashCode.Combine(d.EngineType, d.Transmission);

    public static readonly EquityDelegate<Drivetrain> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return left!.EngineType == right!.EngineType &&
               left.Transmission == right.Transmission;
    };
}