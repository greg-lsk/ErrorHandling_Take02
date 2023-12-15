using Domain.ValueObjects;
using Domain.Equality.Delegates;


namespace Domain.Equality;

public static class DrivetrainEquity
{
    public static readonly HashDelegate<Drivetrain> ValueHash =
        (d) => HashCode.Combine(d.EngineType, d.Transmission);

    public static readonly EquityDelegate<Drivetrain> ByValue =
    (left, right) =>
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return left.EngineType == right.EngineType &&
               left.Transmission == right.Transmission;
    };
}