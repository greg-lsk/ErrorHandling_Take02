namespace ErrorHandling;

public delegate bool Evaluation<TSubject>(TSubject subject, in EvaluationState state);
public delegate bool EvaluationPredicate<TSubject>(TSubject subject);
public delegate TProperty PropertySelector<TSubject, TProperty>(TSubject subject);