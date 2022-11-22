using FH.Application.Common.Abstractions;
using FH.Domain.ValueObjects;
using FH.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        #region Readonly fields

        private readonly ICurrencyService _currencyService;
        private readonly ILoggerService _loggerService;

        #endregion

        #region Ctor

        public CurrencyController(ICurrencyService currencyService, ILoggerService loggerService)
        {
            _currencyService = currencyService;
            _loggerService = loggerService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [ProducesResponseType(typeof(Symbols), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Get()
        {
            try
            {
                Symbols currencies = await _currencyService.GetCurrenciesAsync();

                if (currencies == null)
                    return NotFound();

                IEnumerable<Currency> c =currencies.GetType().GetProperties()
                    .Where(x => x.PropertyType == typeof(string))
                    .Select(x => new Currency(x.Name, x.GetValue(currencies).ToString()));

                _loggerService.LogInfo("Logger");

                return Ok(c.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
