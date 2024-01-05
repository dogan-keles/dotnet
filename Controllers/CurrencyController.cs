using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkintechRestApiDemo.Business;
using WorkintechRestApiDemo.Domain.ApiLayer;
using WorkintechRestApiDemo.Domain;

namespace WorkintechRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        protected readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }


        [HttpGet(Name = "GetCurrency")]
        public async Task<CurrencyResponse> Get()
        {

            return await currencyService.GetCurrency();
        }

        [HttpPost(Name = "GetCurrencyFromApiLayer")]
        public async Task<object> Post(string startDate, string endDate)
        {
            ApiLayerResponse response = await currencyService.PostCurrencyToApiLayer(startDate, endDate);
            if (!response.success)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest("Hata oluştu");
            }
            return response;
        }
    }
}
