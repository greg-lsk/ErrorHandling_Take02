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
}