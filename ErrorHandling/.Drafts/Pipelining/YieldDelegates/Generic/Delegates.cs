using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.Pipelining.YieldDelegates.Generic;

public delegate Result<TSubject> Yield<TSubject>(TSubject subject);
public delegate Result<TSubject> Yield<TSubject, T1>(TSubject subject, T1 arg01);
public delegate Result<TSubject> Yield<TSubject, T1, T2>(TSubject subject, T1 arg01, T2 arg02);
public delegate Result<TSubject> Yield<TSubject, T1, T2, T3>(TSubject subject, T1 arg01, T2 arg02, T3 arg03);