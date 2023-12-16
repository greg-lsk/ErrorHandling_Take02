using Domain.ValueObjects;
using Domain.Entities.Abstractions;

namespace Domain.Entities;
public class Car(
    PowerUnit[] powerUnits,
    UtilitySpecs utillitySpecs) : BaseEntity
{
    public PowerUnit[] PowerUnits { get; } = powerUnits;
    public UtilitySpecs UtillitySpecs { get; } = utillitySpecs;
}