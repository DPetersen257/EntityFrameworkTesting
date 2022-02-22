using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1;

public class DoSomethingClass
{
    private readonly ILogger _logger;

    public string SomeString { get; set; } = "";

    public DoSomethingClass(ILogger<DoSomethingClass> logger) => _logger = logger;

    public DoSomethingClass()
    {
    }

    public string DoSomething()
    {
        SomeString = "somethingDone";
        Thread.Sleep(1000);
        return SomeString;
    }
}
