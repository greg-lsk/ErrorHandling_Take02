using ErrorHandling.Reporting.Abstract;


namespace ErrorHandling.Reporting;

internal class EvaluationReport : IdentifiableReport
{
    internal List<Guid>? externalReports;
    private List<string>? _subjectsInfo;

    private int _linksProvided;

    internal int NextLink => _linksProvided++;
    internal bool HasErrors => Flags is not null;


    internal EvaluationReport() : base() { }


    internal void RegisterFlag(ref int reportLink, Enum flag, IncomplianceSeverity severity)
    {
        switch (OnFlagRegistration(reportLink))
        {
            case OnIncompliance.CreateList:
                Flags = new() { new(flag, severity) };
                reportLink = Flags.Count - 1;
                break;

            case OnIncompliance.IndexedAdd:
                var collection = Flags![reportLink];
                collection.Add(flag, severity);
                Flags![reportLink] = collection;
                break;

            case OnIncompliance.NewFlagCollection:
                Flags!.Add(new(flag, severity));
                reportLink = Flags.Count - 1;
                break;
        }
    }

    internal void TryRegisterSubjectInfo(ref int reportLink, string subjectInfo)
    {
        switch (OnSubjectRegistration(reportLink))
        {
            case OnSubjectInfo.CreateList:
                _subjectsInfo = new() { subjectInfo };
                break;

            case OnSubjectInfo.NewSubjectInfo:
                _subjectsInfo!.Add(subjectInfo);
                break;

            case OnSubjectInfo.AlreadyRegistered:
                break;
        }
    }

    internal void LogExternal(IdentifiableReport report)
    {
        MergeWith(report);

        if (report.Flags is null) return;

        if (externalReports is not null)
        {
            externalReports.Add(report.ReportId);
            return;
        }

        externalReports = new() { report.ReportId };
    }

    internal bool EvaluationYieldedErrors(int reportLink) 
        => Flags is not null && reportLink <= Flags.Count;


    private enum OnIncompliance
    {
        CreateList,
        NewFlagCollection,
        IndexedAdd
    }
    private OnIncompliance OnFlagRegistration(int reportLink)
    {
        if (Flags is null) return OnIncompliance.CreateList;

        return reportLink.CompareTo(Flags.Count - 1) switch
        {
            1 => OnIncompliance.NewFlagCollection,
            _ => OnIncompliance.IndexedAdd 
        };
    }
    
    private enum OnSubjectInfo
    {
        CreateList,
        NewSubjectInfo,
        AlreadyRegistered
    }
    private OnSubjectInfo OnSubjectRegistration(int reportLink)
    {
        if (_subjectsInfo is null) return OnSubjectInfo.CreateList;

        return reportLink.CompareTo(_subjectsInfo.Count - 1) switch
        {
            1 => OnSubjectInfo.NewSubjectInfo,
            _ => OnSubjectInfo.AlreadyRegistered
        };  
    }



    internal string StringRep()
    {
        if (Flags is null) return string.Empty;

        string returnString = string.Empty;
        for (int i = 0; i < Flags.Count; ++i)
        {
            returnString += $"[Subject]: {_subjectsInfo![i]}{Flags[i].LogString()}";
        }

        return returnString;
    }
}