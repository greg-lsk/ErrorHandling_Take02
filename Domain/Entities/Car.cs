using Domain.Enums;
using Domain.ValueObjects;
using Domain.Entities.Abstractions;


namespace Domain.Entities;
public class Car(
    PowerUnit[] powerUnits,
    Transmission transmission,
    UtilitySpecs utillitySpecs) : BaseEntity
{
    public PowerUnit[] PowerUnits { get; } = powerUnits;
    public Transmission Transmission { get; } = transmission;
    public UtilitySpecs UtillitySpecs { get; } = utillitySpecs;

}