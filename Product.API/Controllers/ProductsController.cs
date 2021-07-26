

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Product.API.Exceptions;
using Product.API.InputModels;
using Product.API.Services;
using Product.API.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly LinkGenerator _linkGenerator;

        public ProductsController(IProductService productService, LinkGenerator linkGenerator)
        {
            this._productService = productService;
            this._linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult> Get(
                        [FromQuery, Range(1, int.MaxValue)] int page = 1,
                        [FromQuery, Range(1, 50)] int quantity = 5)
        {
            try
            {
                var result = await _productService.GetAllProductsAsync(page, quantity);

                if (!result.Any())
                    return NoContent();

                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{productId:int}")]
        public ActionResult Get([FromRoute] int productId)
        {
            try
            {
                var result = _productService.GetProduct(productId);

                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> Get([FromRoute] string name)
        {
            try
            {
                var result = await _productService.GetProductAsync(name);

                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductInputModel model)
        {
            try
            {
                var result = await _productService.InsertProductAsync(model);

                var uri = _linkGenerator.GetPathByAction("Get",
                    "Products",
                    new { productId = result.ProductId }
                    );
                return Created(uri, result);
            }
            catch (ProductNameIsNotUniqueException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NegativeProductPriceException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPut("{productId:int}")]
        public async Task<ActionResult> Put(
            [FromRoute] int productId,
            [FromBody] ProductInputModel model)
        {
            try
            {
                var result = await _productService.UpdateProductAsync(productId,model);
                return Ok(result);
            }
            catch (ProductNameIsNotUniqueException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NegativeProductPriceException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(
            [FromRoute] int productId)
        {
            try
            {
                await _productService.DeleteProductAsync(productId);
                return Ok();
            }
            catch (ProductNameIsNotUniqueException ex)
            {
                return Conflict(ex.Message);
            }
            catch (NegativeProductPriceException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
