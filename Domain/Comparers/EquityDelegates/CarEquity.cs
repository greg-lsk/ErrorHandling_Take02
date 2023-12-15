using Domain.Equality;
using Domain.Entities;


namespace Domain.Comparers.EquityDelegates;

public static class CarEquity
{
    public static Hash<Car> IdHash => BaseEntityEquity.IdHash;
    public static Equity<Car> ById => BaseEntityEquity.ById;


    public static readonly Hash<Car> ValueHash =
        c => HashCode.Combine(c.Id,
                              UtilitySpecsEquity.ValueHash(c.UtillitySpecs),
                              DrivetrainEquity.ValueHash(c.Drivetrain));


    public static readonly Equity<Car> ByValue =
    (left, right) =>
    {
        if (Equity.Inferred(left, right)) return true;

        return BaseEntityEquity.ByValue(left, right) &&
               UtilitySpecsEquity.ByValue(left!.UtillitySpecs, right!.UtillitySpecs) &&
               DrivetrainEquity.ByValue(left.Drivetrain, right.Drivetrain);
    };
}