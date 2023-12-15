using Domain.Enums;


namespace Domain.ValueObjects;

public class Drivetrain(EngineType engineType, Transmission transmission)
{
    public EngineType EngineType { get; } = engineType;
    public Transmission Transmission { get; } = transmission;
}