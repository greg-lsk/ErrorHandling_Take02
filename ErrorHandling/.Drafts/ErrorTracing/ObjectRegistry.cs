using ErrorHandling.Drafts.Identification;


namespace ErrorHandling.Drafts;

internal struct ObjectRegistry
{
    private HashSet<RefId>? _refSubjectsId;
    private HashSet<ValueId>? _valueSubjectsId;

    internal bool TryAdd<TSubject>(TSubject subject) where TSubject : class
    {
        _refSubjectsId ??= new();

        return _refSubjectsId.Add(new RefId(subject));
    }

    internal bool TryAdd<TSubject>(Evaluatable<TSubject> subject) where TSubject : struct
    {
        _valueSubjectsId ??= new();

        return _valueSubjectsId.Add(new ValueId(subject.Id));
    }

    internal readonly bool Contains(RefId refId) 
        => _refSubjectsId is not null && _refSubjectsId.Contains(refId);

    internal readonly bool Contains(ValueId valueId) 
        => _valueSubjectsId is not null && _valueSubjectsId.Contains(valueId);
}