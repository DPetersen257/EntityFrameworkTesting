using ClassLibrary1.Data_Access.Repositories.Interfaces;
using ClassLibrary1.Models.Interfaces;

namespace ClassLibrary1.Data_Access.Repositories;

public class CategoryRepository : Repository<ICategory>, ICategoryRepository
{
    public CategoryRepository(MyAppContext context) : base(context)
    {
    }
}
