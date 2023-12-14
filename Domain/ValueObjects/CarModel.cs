using Domain.Entities.Abstractions;


namespace Domain.ValueObjects;

public class CarModel(string name,
                      CarManufacturer manufacturedBy,
                      ModelSpecifications specifications) : BaseEntity
{
    public string Name { get; } = name;
    public CarManufacturer ManufacturedBy { get; } = manufacturedBy;
    public ModelSpecifications Specifications { get; } = specifications;

    public override bool Equals(object? obj) =>
        obj is CarModel model &&
        Id.Equals(model.Id) &&
        Name == model.Name &&
        EqualityComparer<CarManufacturer>.Default.Equals(ManufacturedBy, model.ManufacturedBy) &&
        EqualityComparer<ModelSpecifications>.Default.Equals(Specifications, model.Specifications);
    
    public override int GetHashCode() => 
        HashCode.Combine(Id, Name, ManufacturedBy, Specifications);
}