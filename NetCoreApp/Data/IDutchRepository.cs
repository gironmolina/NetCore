using System.Collections.Generic;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}