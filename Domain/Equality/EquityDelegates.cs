﻿namespace Domain.Equality;


public delegate bool EquityDelegate<T>(T? left, T? right);
public delegate int HashDelegate<T>(T value);