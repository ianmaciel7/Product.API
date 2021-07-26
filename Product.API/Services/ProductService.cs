using Product.API.Exceptions;
using Product.API.InputModels;
using Product.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = _productRepository.GetProductAsync(productId);

            if (product==null)
                throw new ProductNotFoundException();

            _productRepository.DeleteProduct(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(int page, int quantity)
        {
           var products = _productRepository.GetAllProducts().ToArray();
            return await Task.FromResult(products.Skip((page - 1) * quantity).Take(quantity));
        }

        public async Task<ProductViewModel> GetProduct(int productId)
        {
            var product = _productRepository.GetProductAsync(productId);

            if (product == null)
                throw new ProductNotFoundException();

            return await Task.FromResult(product);
        }

        public async Task<ProductViewModel> GetProductAsync(string name)
        {
            var product = _productRepository.GetProductAsync(name);

            if (product == null)
                throw new ProductNotFoundException();

            return await Task.FromResult(product);
        }

        public async Task<ProductViewModel> InsertProductAsync(ProductInputModel model)
        {

            if (model.Price < 0) throw new NegativeProductPriceException();
            if (_productRepository.GetProductAsync(model.Name) != null) throw new ProductNameIsNotUniqueException();

            var p = _productRepository.InsertProduct(new ProductViewModel
            {           
                Price = model.Price,
                Name = model.Name,
                Category = model.Category,
                StockNumber = model.StockNumber
            });
            await _productRepository.SaveChangesAsync();
            return p;
        }

        public async Task<ProductViewModel> UpdateProductAsync(int productId, ProductInputModel model)
        {
            var product =  _productRepository.GetProductAsync(productId);

            if(product == null) throw new ProductNotFoundException();
            if(model.Price < 0) throw new NegativeProductPriceException();
            if(_productRepository.GetProductAsync(model.Name) != null) throw new ProductNameIsNotUniqueException();

            var p = _productRepository.UpdateProduct(product, new ProductViewModel
            {
                Price = model.Price,
                Name = model.Name,
                Category = model.Category
            });
            await _productRepository.SaveChangesAsync();
            return p;
        }


    }
}
