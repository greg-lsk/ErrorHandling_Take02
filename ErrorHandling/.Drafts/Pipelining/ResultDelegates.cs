using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.Pipelining;

public delegate Result<TSubject> ResultPipe<TSubject>();
public delegate Result<TSubject> ResultPipe<T1, TSubject>(T1 arg01);
public delegate Result<TSubject> ResultPipe<T1, T2, TSubject>(T1 arg01, T2 arg02);
public delegate Result<TSubject> ResultPipe<T1, T2, T3, TSubject>(T1 arg01, T2 arg02, T3 arg03);
public delegate Result<TSubject> ResultPipe<T1, T2, T3, T4, TSubject>(T1 arg01, T2 arg02, T3 arg03, T4 arg04);


public delegate VoidResult VoidPipe();
public delegate VoidResult VoidPipe<T1>(T1 arg01);
public delegate VoidResult VoidPipe<T1, T2>(T1 arg01, T2 arg02);
public delegate VoidResult VoidPipe<T1, T2, T3>(T1 arg01, T2 arg02, T3 arg03);
public delegate VoidResult VoidPipe<T1, T2, T3, T4>(T1 arg01, T2 arg02, T3 arg03, T4 arg04);