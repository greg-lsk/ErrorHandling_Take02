using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic;

public delegate Result<TSubject> Yield<TSubject>(TSubject subject);
public delegate Result<TSubject> Yield<T1, TSubject>(T1 arg01, TSubject subject);
public delegate Result<TSubject> Yield<T1, T2, TSubject>(T1 arg01, T2 arg02, TSubject subject);
public delegate Result<TSubject> Yield<T1, T2, T3, TSubject>(T1 arg01, T2 arg02, T3 arg03, TSubject subject);