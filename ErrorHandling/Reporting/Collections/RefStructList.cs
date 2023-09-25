using System.Collections.Generic;

namespace ErrorHandling.Reporting.Collections;

internal class RefStructList<TStruct> where TStruct: struct
{
    private readonly List<TStruct> List;


    internal RefStructList() => List = new();
    

    internal void Add(TStruct structToAdd) => List.Add(structToAdd);

    internal ref readonly TStruct GetRef(int index)
    {
        return ref System.Runtime.InteropServices.CollectionsMarshal.AsSpan(List)[index];
    }

}