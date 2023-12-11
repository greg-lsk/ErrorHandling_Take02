using ErrorHandling.ResultUtilities;

namespace ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic.Contsructive;

public delegate Result<TSubject> Yield<TSubject>();
public delegate Result<TSubject> Yield<TSubject, T1>(T1 arg01);
public delegate Result<TSubject> Yield<TSubject, T1, T2>(T1 arg01, T2 arg02);
public delegate Result<TSubject> Yield<TSubject, T1, T2, T3>(T1 arg01, T2 arg02, T3 arg03);