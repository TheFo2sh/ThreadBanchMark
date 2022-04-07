using BenchmarkDotNet.Attributes;

[ThreadingDiagnoser] // ENABLE the diagnoser
public class TestClass
{
    private Type[] types = new[] { typeof(Student), typeof(Student), typeof(Student), typeof(Student) };
    
    
    [Benchmark]
    public async Task AsyncEnumerable()
    {
        var result=   await types.ToAsyncEnumerable()
            .Select(type => Activator.CreateInstance(type, Guid.NewGuid().ToString()))
            .ToListAsync();
    }
    [Benchmark]
    public void Linq()
    {
        var result=   types.Select(type => Activator.CreateInstance(type, Guid.NewGuid().ToString())).ToList();
    }
}