using ErrorHandling.EvaluationBuilders;
using ErrorHandling.EvaluationBuilders.Internal;


namespace ErrorHandling;

public abstract class EvaluationFor<TSubject>
{
    public static EvaluationBuilder<TSubject> WithPredicate(EvaluationPredicate<TSubject> predicate) 
        => new PredicateEvaluationBuilder<TSubject>().WithPredicate(predicate);

    public static BatchEvaluationBuilder<TSubject> Sequencial() => new();

    public static EvaluationBuilder<TSubject> WithSelection<TProperty>(
        PropertySelector<TSubject, TProperty> selector, 
        Evaluation<TProperty> evaluation)
        => new ComposedEvaluationBuilder<TSubject, TProperty>().WithSelection(selector, evaluation);
}