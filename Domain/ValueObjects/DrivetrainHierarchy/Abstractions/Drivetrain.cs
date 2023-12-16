using Domain.Enums;

namespace Domain.ValueObjects;

public abstract class Drivetrain(
    int odometerReading,
    double emissions,
    Transmission transmission)
{
    public abstract PowerSource PowerSource { get; }

    public double Emissions { get; } = emissions;

    public Transmission Transmission { get; } = transmission;

    public int OdometerReading { get; private set; } = odometerReading;
}