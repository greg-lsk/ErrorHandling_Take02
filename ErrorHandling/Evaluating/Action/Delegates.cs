using ErrorHandling.Evaluating;
using ErrorHandling.Rule;


namespace ErrorHandling.Evaluating.Action;

internal delegate bool EvaluationAction<TSubject>(in Evaluation evaluation,
                                                  TSubject subject,
                                                  DomainRule rule);