using SampleUnitTestingApp.Models;
using System.Collections.Generic;

namespace SampleUnitTestingApp.Data
{
    public interface IProductRepository
    {
        IList<Product> FindAll();
        Product FindByName(string productName);
        Product FindById(int productId);
        bool Save(Product target);

    }
}
