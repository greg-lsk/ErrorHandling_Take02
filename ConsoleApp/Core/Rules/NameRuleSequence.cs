using ConsoleApp.Core.ValueTypes;
using ErrorHandling.Rule;


namespace ConsoleApp.Core.Rules;

public static class NameRuleSequence
{
    public static readonly RuleSequence<string> ForStringFormat = new
    (
        (StringRule.IsNotEmpty, enablesShortCircuiting: true),
        (NameRule.WithinLength, enablesShortCircuiting: false),
        (StringRule.StartsWithUpperCase, enablesShortCircuiting: false)
    );

    public static readonly RuleSequence<Name> ForValidName = new
    (
        (NameRule.IsNotNull, enablesShortCircuiting: true),
        (NameRule.HasValidStringFormat, enablesShortCircuiting: false)
    );
}