using ErrorHandling.Rule;
using ErrorHandling.Reporting;


namespace ErrorHandling.Evaluating.Actions;

internal delegate bool EvaluationAction<TSubject>(TSubject subject,
                                                  DomainRule rule,
                                                  EvaluationReport report,
                                                  EvaluationBehavior behavior);