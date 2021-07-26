using Product.API.InputModels;
using Product.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public interface IProductRepository
    {
       
        void DeleteProduct(ProductViewModel product);
        Task SaveChangesAsync();
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductAsync(int productId);
        ProductViewModel InsertProduct(ProductViewModel product);
        ProductViewModel UpdateProduct(ProductViewModel product, ProductViewModel newProduct);
        ProductViewModel GetProductAsync(string name);
    }
}
