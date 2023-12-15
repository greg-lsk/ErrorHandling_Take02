using Domain.ValueObjects;
using Domain.Entities.Abstractions;


namespace Domain.Entities;

public class Car(UtillitySpecs utillitySpecs, Drivetrain drivetrain) : BaseEntity
{
    public UtillitySpecs UtillitySpecs { get; } = utillitySpecs;
    public Drivetrain Drivetrain { get; } = drivetrain;
}