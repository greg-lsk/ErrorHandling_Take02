using Domain.ValueObjects;
using Domain.Entities.Abstractions;


namespace Domain.Entities;

public class Car(CarModel model) : BaseEntity
{
    public CarModel Model { get; } = model;
}