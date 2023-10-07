```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
Intel Celeron CPU 1005M 1.90GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT SSE4.2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT SSE4.2


```
--
| Method        | FlagsCaptured | SubjectsEvaluated | Mean          | Gen0     | Allocated |
|--------------:|--------------:|------------------:|--------------:|---------:|----------:|

| StringConcat  |       1       |         1         |     413.3 ns  |   0.3214 |     336 B |
| StringFromSpan|       1       |         1         |     295.7 ns  |   0.3443 |     360 B |
| StringConcat  |       1       |         5         |   2,293.6 ns  |   2.6779 |    2802 B |
| StringFromSpan|       1       |         5         |   1,250.3 ns  |   1.4458 |    1512 B |
| StringConcat  |       1       |        10         |   5,347.2 ns  |   8.0338 |    8406 B |
| StringFromSpan|       1       |        10         |   2,357.3 ns  |   2.8229 |    2953 B |
-
| StringConcat  |      10       |         1         |   4,099.5 ns  |   5.5389 |    5796 B |
| StringFromSpan|      10       |         1         |   1,881.4 ns  |   2.0733 |    2169 B |
| StringConcat  |      10       |         5         |  22,738.1 ns  |  34.5764 |   36216 B |
| StringFromSpan|      10       |         5         |   9,488.4 ns  |  10.0555 |   10523 B |
| StringConcat  |      10       |        10         |  51,421.6 ns  |  86.3647 |   90540 B |
| StringFromSpan|      10       |        10         |  18,761.9 ns  |  19.9890 |   20958 B |

| StringConcat  |      20       |         1         |   9,959.9 ns  |  17.5171 |   18324 B |
| StringFromSpan|      20       |         1         |   3,653.6 ns  |   3.9825 |    4169 B |
| StringConcat  |      20       |         5         |  53,036.1 ns  | 100.9521 |  105662 B |
| StringFromSpan|      20       |         5         |  18,234.1 ns  |  19.5923 |   20526 B |
| StringConcat  |      20       |        10         | 118,619.8 ns  | 235.2295 |  246444 B |
| StringFromSpan|      20       |        10         |  36,705.8 ns  |  38.9404 |   40964 B |
-
