using ClassLibrary1.Models.Interfaces;
using ClassLibrary1.Repositories.Interfaces;

namespace ClassLibrary1.Data_Access.Repositories;
public class ProductRepository : Repository<IProduct>, IProductRepository
{
    public ProductRepository(MyAppContext context) : base(context)
    {
    }
}