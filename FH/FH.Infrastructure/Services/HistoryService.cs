using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using FH.Domain.Exceptions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FH.Infrastructure.Services
{
    public sealed class HistoryService : IHistoryService
    {
        #region Readonly Fields

        private readonly IExternalCurrencyApi _extCurrency;

        #endregion

        #region Ctor

        public HistoryService(IExternalCurrencyApi extCurrency)
        {
            _extCurrency = extCurrency;
        }

        #endregion

        #region Methods

        public async Task<HistoryEntity> GetHistory(string baseCur, string excCur)
        {
            try
            {
                DateTime startDate = DateTime.Now.Date;

                string jsonResult = await _extCurrency.GetRateHistoryJson(baseCur, excCur);

                if (jsonResult == null)
                    throw new RootSerializationException($"History result could not be serialized");

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
