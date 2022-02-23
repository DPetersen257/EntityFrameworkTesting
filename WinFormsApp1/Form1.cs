using ClassLibrary1;
using ClassLibrary1.Data_Access;
using ClassLibrary1.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly ILogger _logger;
    private readonly MyAppContext _context;
    public Form1(ILogger<Form1> logger, MyAppContext context)
    {
        _logger = logger;
        _context = context;

        Category c = new Category
        {
            Name = "TestCategory"
        };

        Product p = new Product()
        {
            Name = "TestProduct",
            Category = c
        };

        _context.Products.Add(p);
        _context.SaveChangesAsync();

        var test = _context.Products.ToList();
        _logger.LogInformation("Products: {@Products}", test);
        InitializeComponent();

        _logger.LogInformation("Form initialized");
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        var something = Program.ServiceProvider.GetRequiredService<IDoSomethingClass>();
        string test = something.DoSomething();
    }
}
