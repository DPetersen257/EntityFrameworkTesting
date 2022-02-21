namespace ClassLibrary1.Models.Interfaces;

public interface IProduct
{
    int ProductID { get; set; }
    string Name { get; set; }
    Category Category { get; set; }
}