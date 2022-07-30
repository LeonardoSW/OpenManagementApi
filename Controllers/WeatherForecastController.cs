using Domain.DTOs.Common;
using Domain.DTOs.OutputModels;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace OpenManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductServices _productServices;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        [HttpPost("/insert")]
        public async Task InsertProduct([FromQuery] Product product)
            => await _productServices.InsertProduct(product);

        [HttpGet("/list")]
        public async Task<ProductListOutputModel> GetProductList()
            => await _productServices.GetProducts();

        [HttpPost("/teste")]
        public async Task Teste(IFormFile? file)
        {
            var scann = new AntiVirus.Scanner();

            if (file.ContentType != "application/pdf") // an options is use into fluent validation
                await Task.Delay(1);

            await Task.Delay(1);
        }
    }
}