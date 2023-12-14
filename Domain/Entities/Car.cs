using Domain.ValueObjects;
using Domain.Entities.Abstractions;


namespace Domain.Entities;

public class Car(CarModel model) : BaseEntity
{
    public CarModel Model { get; } = model;

    public override bool Equals(object? obj) =>
        obj is Car car &&
        Id.Equals(car.Id) &&
        EqualityComparer<CarModel>.Default.Equals(Model, car.Model);

    public override int GetHashCode() => HashCode.Combine(Id, Model);
}