```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Celeron CPU 1005M 1.90GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT SSE4.2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT SSE4.2


```
| Method             | Mean      | Error    | StdDev   | Ratio | Gen0   | Allocated | Alloc Ratio |
|------------------- |----------:|---------:|---------:|------:|-------:|----------:|------------:|
| StringConcatReturn | 263.66 ns | 3.863 ns | 3.425 ns |  1.00 | 0.0992 |     104 B |        1.00 |
| SpanReturn         |  71.79 ns | 0.526 ns | 0.492 ns |  0.27 | 0.0688 |      72 B |        0.69 |
| MemoryReturn       |  95.25 ns | 0.263 ns | 0.219 ns |  0.36 | 0.0688 |      72 B |        0.69 |


```
Persentage Differences

```
|      __time__      |__StringConcatReturn__|   __SpanReturn__   |  __MemoryReturn__  |
|--------------------|---------------------:|-------------------:|--------------------:
| StringConcatReturn |          --          |       -72.7%       |       -63.8%       |
| SpanReturn         |        +227.2%       |         --         |       +32.6%       |
| MemoryReturn       |        +176.8%       |       -24.6%       |         --         |


|      __alloc__     |__StringConcatReturn__|   __SpanReturn__   |  __MemoryReturn__  |
|--------------------|---------------------:|-------------------:|--------------------:
| StringConcatReturn |          --          |       -30.7%       |       -30.7%       |
| SpanReturn         |        +44.4%        |         --         |         0%         |
| MemoryReturn       |        +44.4%        |         0%         |         --         |