namespace Domain.ValueObjects;

public class UtillitySpecs(int numberOfSeats,
                           int numberOfDoors,
                           double bootCapacity)
{
    public int NumberOfSeats { get; private set; } = numberOfSeats;
    public int NumberOfDoors { get; private set; } = numberOfDoors;
    public double BootCapacity { get; private set; } = bootCapacity;
}