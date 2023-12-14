using Domain.Entities.Abstractions;


namespace Domain.ValueObjects;

public class CarManufacturer(string name, List<CarModel> models) : BaseEntity
{
    public string Name { get; } = name;
    public List<CarModel> Models { get; } = models;

    public override bool Equals(object? obj) => 
        obj is CarManufacturer manufacturer &&
        Name == manufacturer.Name;
    
    public override int GetHashCode() => HashCode.Combine(Name);
}