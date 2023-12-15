namespace Domain.Equality;


public delegate bool Equity<in T>(T? left, T? right);
public delegate int Hash<in T>(T value);