using Domain.ValueObjects;
using Domain.Entities.Abstractions;
using Domain.ValueObjects.DrivetrainHierarchy.Abstractions;


namespace Domain.Entities;

public class Car(UtilitySpecs utillitySpecs, Drivetrain drivetrain) : BaseEntity
{
    public UtilitySpecs UtillitySpecs { get; } = utillitySpecs;
    public Drivetrain Drivetrain { get; } = drivetrain;
}