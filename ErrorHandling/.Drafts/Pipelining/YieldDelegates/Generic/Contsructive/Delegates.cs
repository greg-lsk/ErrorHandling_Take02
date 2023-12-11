using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;

public delegate Result<TSubject> CtorPipe<TSubject>();
public delegate Result<TSubject> CtorPipe<T1, TSubject>(T1 arg01);
public delegate Result<TSubject> CtorPipe<T1, T2, TSubject>(T1 arg01, T2 arg02);
public delegate Result<TSubject> CtorPipe<T1, T2, T3, TSubject>(T1 arg01, T2 arg02, T3 arg03);