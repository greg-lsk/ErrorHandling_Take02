
namespace Domain.ValueObjects;

public class ModelSpecifications(int numberOfSeats,
                                 int numberOfDoors,
                                 double bootCapacity,
                                 Drivetrain drivetrain)
{
    public int NumberOfSeats { get; } = numberOfSeats;
    public int NumberOfDoors { get; } = numberOfDoors;
    public double BootCapacity { get; } = bootCapacity;
    public Drivetrain Drivetrain { get; } = drivetrain;

    public override bool Equals(object? obj) =>
        obj is ModelSpecifications specifications &&
        NumberOfSeats == specifications.NumberOfSeats &&
        NumberOfDoors == specifications.NumberOfDoors &&
        BootCapacity == specifications.BootCapacity &&
        EqualityComparer<Drivetrain>.Default.Equals(Drivetrain, specifications.Drivetrain);
    
    public override int GetHashCode() => 
        HashCode.Combine(NumberOfSeats, NumberOfDoors, BootCapacity, Drivetrain);
}