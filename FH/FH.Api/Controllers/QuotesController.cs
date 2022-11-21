using FH.Api.Dtos;
using FH.Application.History.Requests.Queries;
using FH.Application.Quote.Requests.QueryRequests;
using FH.Domain.DbModels;
using FH.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        #region Readonly Field

        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Methods

        [HttpGet("{baseCcy}/{quoteCcy}/{amount}")]
        public async Task<IActionResult>GetQuote(string baseCcy, string quoteCcy, decimal amount)
        {
            try
            {
                if (string.IsNullOrEmpty(baseCcy))
                    throw new ArgumentNullException(nameof(baseCcy), "Invalid parameter");

                if(string.IsNullOrEmpty(quoteCcy))
                    throw new ArgumentNullException(nameof(quoteCcy), "Invalid parameter");

                if (amount < 0)
                    throw new ArgumentNullException(nameof(amount), "Invalid parameter");

                QuoteEntity quoteResult = await _mediator.Send(new GetQuoteRequest(MapToEntity(new QuoteRequestDto() {
                    Amount = amount,
                    BaseCcy = baseCcy,
                    QuoteCcy = quoteCcy
                })));

                IEnumerable<History> history = await _mediator.Send(new GetHistoryRequest(baseCcy, quoteCcy));

                //Customer history
                quoteResult.History = history;

                return Ok(MapToDto(quoteResult));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private static QuoteEntity MapToEntity(QuoteRequestDto dto) => new QuoteEntity(dto.BaseCcy, dto.QuoteCcy, dto.Amount);

        private static QuoteResponseDto MapToDto(QuoteEntity entity) =>
            new QuoteResponseDto
            {
                BaseCcy = entity.BaseCcy,
                Date = entity.Date,
                QuoteAmount = entity.QuoteAmount,
                QuoteCcy = entity.QuoteCcy,
                History = MaptoHistoryDto(entity.History)
            };

        private static List<HistoryDto>MaptoHistoryDto(IEnumerable<History>history)
        {
            var historyList = new List<HistoryDto>();
            history.ToList().ForEach(x =>
            {
                historyList.Add(new HistoryDto { Rate = x.Value, Timestamp = x.Date });
            });

            return historyList;
        }

        #endregion

    }
}
