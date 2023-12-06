using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating.Actions;

internal delegate bool EvaluationAction<TSubject>(in Evaluation evaluation,
                                                  TSubject subject,
                                                  DomainRule rule);