using ErrorHandling.Rule;


namespace ConsoleApp.Core.Rules;

public static class NameRuleSequence
{
    public static readonly RuleSequence<string> StringFormat = new
    (
        (StringRule.IsNotEmpty, enablesShortCircuiting: true),
        (NameRule.WithinLength, enablesShortCircuiting: false),
        (StringRule.StartsWithUpperCase, enablesShortCircuiting: false)
    );
}