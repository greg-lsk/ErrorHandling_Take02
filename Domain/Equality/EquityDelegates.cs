namespace Domain.Equality;


public delegate bool EquityDelegate<in T>(T? left, T? right);
public delegate int HashDelegate<in T>(T value);