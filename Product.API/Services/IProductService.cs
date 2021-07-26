using Product.API.InputModels;
using Product.API.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public interface IProductService
    {
        Task<ProductViewModel> GetProduct(int ProductId);
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(int page, int quantity);
        Task DeleteProductAsync(int productId);
        Task<ProductViewModel> UpdateProductAsync(int productId, ProductInputModel model);
        Task<ProductViewModel> InsertProductAsync(ProductInputModel model);
        Task<ProductViewModel> GetProductAsync(string name);
        Task<IOrderedEnumerable<ProductViewModel>> GetAllProductsAsync(int page, int quantity, string orderBy,bool ascending);
    }
}
