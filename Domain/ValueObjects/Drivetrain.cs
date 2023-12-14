using Domain.Enums;


namespace Domain.ValueObjects;

public class Drivetrain(EngineType engineType, Transmission transmission)
{
    public EngineType EngineType { get; } = engineType;
    public Transmission Transmission { get; } = transmission;

    public override bool Equals(object? obj) => 
        obj is Drivetrain drivetrain &&
        EngineType == drivetrain.EngineType &&
        Transmission == drivetrain.Transmission;
    
    public override int GetHashCode() => HashCode.Combine(EngineType, Transmission);
}