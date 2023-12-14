using Domain.Entities.Abstractions;


namespace Domain.Entities;

public class CarInventory(Car car, int availableUnits) : BaseEntity
{
    public Car Car { get; } = car;
    public int AvailableUnits { get; } = availableUnits;

    public override bool Equals(object? obj)=>
        obj is CarInventory inventory &&
        Id.Equals(inventory.Id) &&
        EqualityComparer<Car>.Default.Equals(Car, inventory.Car) &&
        AvailableUnits == inventory.AvailableUnits;
    
    public override int GetHashCode() => HashCode.Combine(Id, Car, AvailableUnits);
}