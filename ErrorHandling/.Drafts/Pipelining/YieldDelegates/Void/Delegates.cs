using ErrorHandling.ResultUtilities;


namespace ErrorHandling.Drafts.Pipelining.YieldDelegates.Void;

public delegate VoidResult Yield();
public delegate VoidResult Yield<T1>(T1 arg01);
public delegate VoidResult Yield<T1, T2>(T1 arg01, T2 arg02);
public delegate VoidResult Yield<T1, T2, T3>(T1 arg01, T2 arg02, T3 arg03);
public delegate VoidResult Yield<T1, T2, T3, T4>(T1 arg01, T2 arg02, T3 arg03, T4 arg04);