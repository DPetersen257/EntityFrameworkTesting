using ClassLibrary1.Models.Interfaces;
using ClassLibrary1.Repositories.Interfaces;

namespace ClassLibrary1.Data_Access.Repositories.Interfaces;

/// <summary>
/// A class for holding connections - a sub element of an application.
/// <para>Examples could be Nuix - US, DMX - US.</para>
/// </summary>
public interface ICategoryRepository : IRepository<ICategory>
{
}
