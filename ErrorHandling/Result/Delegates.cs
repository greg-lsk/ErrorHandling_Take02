namespace ErrorHandling.Result;


public delegate ref TStruct StructSelector<TEntity, TStruct>(TEntity entity)
    where TStruct : struct;


public delegate TClass RefTypeSelector<TEntity, TClass>(TEntity entity)
    where TClass : class;


public delegate IResult OnStructAction<TEntity, TStruct, T1>(StructSelector<TEntity, TStruct> selector,
                                                             TEntity ofEntity,
                                                             T1 arg01) 
    where TStruct : struct;

public delegate IResult OnRefTypeAction<TEntity, TClass, T1>(RefTypeSelector<TEntity, TClass> selector,
                                                             TEntity ofEntity,
                                                             T1 arg01)
    where TClass : class;