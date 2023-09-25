namespace ErrorHandling;


public readonly struct IncomplianceRecord<TSubject>
{
    public readonly Func<TSubject, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject) => Delegate.Invoke(subject);
}

public readonly struct IncomplianceRecord<TSubject, T1>
{
    public readonly Func<TSubject, T1, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, T1, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject, T1 param) => Delegate.Invoke(subject, param);
}

public readonly struct IncomplianceRecord<TSubject, T1, T2>
{
    public readonly Func<TSubject, T1, T2, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, T1, T2, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject, T1 param1, T2 param2)
        => Delegate.Invoke(subject, param1, param2);
}

public readonly struct IncomplianceRecord<TSubject, T1, T2, T3>
{
    public readonly Func<TSubject, T1, T2, T3, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, T1, T2, T3, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject, T1 param1, T2 param2, T3 param3)
        => Delegate.Invoke(subject, param1, param2, param3);
}

public readonly struct IncomplianceRecord<TSubject, T1, T2, T3, T4>
{
    public readonly Func<TSubject, T1, T2, T3, T4, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, T1, T2, T3, T4, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject, T1 param1, T2 param2, T3 param3, T4 param4)
        => Delegate.Invoke(subject, param1, param2, param3, param4);
}

public readonly struct IncomplianceRecord<TSubject, T1, T2, T3, T4, T5>
{
    public readonly Func<TSubject, T1, T2, T3, T4, T5, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, T1, T2, T3, T4, T5, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        => Delegate.Invoke(subject, param1, param2, param3, param4, param5);
}

public readonly struct IncomplianceRecord<TSubject, T1, T2, T3, T4, T5, T6>
{
    public readonly Func<TSubject, T1, T2, T3, T4, T5, T6, bool> Delegate;
    public readonly Enum Flag;
    public readonly IncomplianceSeverity Severity;

    public IncomplianceRecord(
        Func<TSubject, T1, T2, T3, T4, T5, T6, bool> incomplianceDelegate,
        Enum flag,
        IncomplianceSeverity severity)
    {
        Delegate = incomplianceDelegate;
        Flag = flag;
        Severity = severity;
    }

    public bool AppliesTo(TSubject subject, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        => Delegate.Invoke(subject, param1, param2, param3, param4, param5, param6);
}