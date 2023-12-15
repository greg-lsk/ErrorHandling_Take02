namespace Domain.ValueObjects;

public class CarModel(string name,
                      ModelSpecifications specifications)
{
    public string Name { get; } = name;
    public ModelSpecifications Specifications { get; } = specifications;
}