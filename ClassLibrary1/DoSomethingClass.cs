using Microsoft.Extensions.Logging;

namespace ClassLibrary1;

public class DoSomethingClass : IDoSomethingClass
{
    private readonly ILogger _logger;

    public string SomeString { get; set; } = "";

    public DoSomethingClass(ILogger<DoSomethingClass> logger) => _logger = logger;

    public string DoSomething()
    {
        _logger.LogInformation("Doing something.");
        SomeString = "somethingDone";
        Thread.Sleep(1000);
        return SomeString;
    }
}
