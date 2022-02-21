using ClassLibrary1.Models.Interfaces;

namespace ClassLibrary1.Models;

/// <summary>
/// A class for holding connections - a sub element of an application.
/// <para>Examples could be Nuix - US, DMX - US.</para>
/// </summary>
public class Category : ICategory
{
    public int CategoryID { get; set; }
    public string Name { get; set; } = "";
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
