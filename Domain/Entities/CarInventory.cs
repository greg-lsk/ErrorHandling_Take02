using Domain.Entities.Abstractions;


namespace Domain.Entities;

public class CarInventory(Car car, int availableUnits) : BaseEntity
{
    public Car Car { get; } = car;
    public int AvailableUnits { get; } = availableUnits;
}