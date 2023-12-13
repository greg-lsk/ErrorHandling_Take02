using ErrorHandling.Reporting;
using ErrorHandling.Reporting.CallStackInfo;


namespace ErrorHandling;

public readonly struct EvaluationState
{
    internal EvaluationInfo TraceInfo { get; }
    internal EvaluationReport Report { get; }


    internal EvaluationState(string callerMemberName, int callerLineNumber)
    {
        Report = new();
        TraceInfo = new(callerMemberName, callerLineNumber);
    }
}