namespace ClassLibrary1.Models.Interfaces;

public interface ICategory
{
    int CategoryID { get; set; }
    string Name { get; set; }
    ICollection<IProduct> Products { get; set; }
}