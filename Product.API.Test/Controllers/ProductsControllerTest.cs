

using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Product.API.InputModels;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Product.API.Test.IntegrationTest.Controllers
{
    public class ProductsControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;
        protected readonly ITestOutputHelper _outputHelper;
        protected readonly HttpClient _httpClient;

        public ProductsControllerTest(WebApplicationFactory<Startup> factory, ITestOutputHelper outputHelper)
        {
            _factory = factory;
            _outputHelper = outputHelper;
            _httpClient = _factory.CreateClient();
        }


        private ProductInputModel _productInputModel;

        [Fact]
        public async Task Register_ReturnSuccessfully_WhenProductIsValid()
        {

            _productInputModel = new ProductInputModel() { Name = "Teste", Price = 0, Category = "Categoria teste", StockNumber = 0 };
            var content = new StringContent(JsonConvert.SerializeObject(_productInputModel), Encoding.UTF8, "application/json");


            var httpResponse = await _httpClient.PostAsync($"api/Products", content);

            _outputHelper.WriteLine($"{nameof(Register_ReturnSuccessfully_WhenProductIsValid)}_{nameof(Register_ReturnSuccessfully_WhenProductIsValid)} :" + await httpResponse.Content.ReadAsStringAsync());
            Assert.Equal(System.Net.HttpStatusCode.Created, httpResponse.StatusCode);
        }

        [Fact]
        public async Task Register_ReturnFailure_WhenProductPriceIsInvalid()
        {
            _productInputModel = new ProductInputModel() { Name = "Teste2", Price = -1, Category = "Categoria teste", StockNumber = 0 };
            var content = new StringContent(JsonConvert.SerializeObject(_productInputModel), Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync($"api/Products", content);

            _outputHelper.WriteLine($"{nameof(Register_ReturnSuccessfully_WhenProductIsValid)}_{nameof(Register_ReturnFailure_WhenProductPriceIsInvalid)} :" + await httpResponse.Content.ReadAsStringAsync());
            Assert.Equal(System.Net.HttpStatusCode.Conflict, httpResponse.StatusCode);
        }

        
    }
}
