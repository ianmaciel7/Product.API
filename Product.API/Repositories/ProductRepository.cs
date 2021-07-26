using Product.API.Data;
using Product.API.InputModels;
using Product.API.Services;
using Product.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void DeleteProduct(ProductViewModel product)
        {
            _appDbContext.Remove(product);
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _appDbContext.Products.ToList();
        }

        public ProductViewModel GetProductAsync(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public ProductViewModel GetProductAsync(string name)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public ProductViewModel InsertProduct(ProductViewModel product)
        {
            var entityEntry = _appDbContext.Products.AddAsync(product);
            return entityEntry.Result.Entity;
        }

        public Task SaveChangesAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public ProductViewModel UpdateProduct(ProductViewModel product, ProductViewModel newProduct)
        {
            product.Category = newProduct.Category;
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.StockNumber = newProduct.StockNumber;
            return product;
        }
    }
}
