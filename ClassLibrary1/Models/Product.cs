using ClassLibrary1.Models.Interfaces;

namespace ClassLibrary1.Models;

public class Product : IProduct
{
    public Product(ICategory category) => Category = category;

    public int ProductID { get; set; }
    public string Name { get; set; } = "";

    public virtual ICategory Category { get; set; }
}
