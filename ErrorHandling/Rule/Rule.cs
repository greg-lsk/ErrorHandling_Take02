using ErrorHandling.Drafts;
using ErrorHandling.Evaluating;

namespace ErrorHandling.Rule;

public delegate bool RulePredicate<TSubject>(TSubject subject);

public class Rule<TSubject>
{
    private readonly Evaluation<TSubject> _evaluation;

    public Rule(RulePredicate<TSubject> predicate,
                IncomplianceSeverity severity,
                Enum? successTag = null,
                Enum? incomplianceTag = null)
    {
        _evaluation = (TSubject subject, in EvaluationState state) =>
        {
            bool ruleApplies = predicate.Invoke(subject);

            if (ruleApplies)
            {
                if (successTag is not null) Console.WriteLine($"[Success]:{successTag}");
                else Console.WriteLine($"[Success]");
            }
            else
            {
                if (incomplianceTag is not null) Console.WriteLine($"[{severity}]:{incomplianceTag}");
                else Console.WriteLine($"[{severity}]");
            }

            return ruleApplies;
        };
    }

   /* internal EvaluationResult AppliesTo(TSubject subject) => _evaluation.Invoke(subject);*/
}