namespace ErrorHandling.Evaluating.Actions;

internal interface IEvaluationActionCarrier<TSubject>
{
    internal EvaluationAction<TSubject> Action { get; }
}