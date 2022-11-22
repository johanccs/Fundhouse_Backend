using FH.Api.Controllers;
using FH.Application.Common.Abstractions;
using FH.Domain.ValueObjects;
using FH.Services.Contracts;
using FH.Services.Services;
using FH.Tests.Services.MockServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FH.Tests.Services.Controllers
{
    public class CurrencyControllerTest
    {
        [Fact]
        public async Task Should_Get_Symbols()
        {
            ILoggerService loggerService = new MockLoggerManager();
            IExternalCurrencyApi mockExternal = new MockExternalServices();
            ICurrencyService mockCurrencyService = new CurrencyService(mockExternal);

            CurrencyController currencyController = new CurrencyController(mockCurrencyService,loggerService);

            var response = await currencyController.Get();

            var statuscode = ((OkObjectResult)response).StatusCode;
            var resultType = ((List<Currency>)((OkObjectResult)response).Value);

            Assert.True(statuscode == 200);
            Assert.True(resultType.Count > 0);
            Assert.True(resultType[0].GetType() == typeof(Currency));

        }
    }
}
