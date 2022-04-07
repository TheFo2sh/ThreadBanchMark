``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i9-10980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|          Method |     Mean |     Error |    StdDev | Completed Work Items | Lock Contentions |
|---------------- |---------:|----------:|----------:|---------------------:|-----------------:|
| AsyncEnumerable | 2.511 μs | 0.0475 μs | 0.0959 μs |                    - |                - |
|            Linq | 2.435 μs | 0.0474 μs | 0.0817 μs |                    - |                - |
