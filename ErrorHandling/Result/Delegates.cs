namespace ErrorHandling.Result;


public delegate ref TStruct StructSelector<TEntity, TStruct>(TEntity entity) 
    where TEntity : class
    where TStruct : struct;