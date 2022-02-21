using ClassLibrary1.Models.Interfaces;

namespace ClassLibrary1.Models;

public class Product : IProduct
{
    public int ProductID { get; set; }
    public string Name { get; set; } = "";

    public virtual Category Category { get; set; }
}
