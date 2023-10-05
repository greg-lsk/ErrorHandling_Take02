```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Celeron CPU 1005M 1.90GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT SSE4.2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT SSE4.2


```
| Method             | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------- |----------:|---------:|---------:|-------:|----------:|
| StringConcatReturn | 247.03 ns | 5.008 ns | 6.150 ns | 0.0992 |     104 B |
| SpanReturn         |  72.41 ns | 0.577 ns | 0.540 ns | 0.0688 |      72 B |
