using FH.Api.Dtos;
using FH.Application.History.Requests.Queries;
using FH.Application.Quote.Requests.QueryRequests;
using FH.Domain.Entities;
using FH.Domain.ValueObjects;
using MediatR;
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
        [ProducesResponseType(typeof(QuoteEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
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

                IEnumerable<Domain.DbModels.History> history = await _mediator.Send(new GetHistoryRequest(baseCcy, quoteCcy));

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

        private static QuoteResponseDto MapToDto(QuoteEntity entity)
        {
            QuoteResponseDto quoteResponse = new();
            quoteResponse.BaseCcy = entity.BaseCcy;
            quoteResponse.Date = entity.Date;
            quoteResponse.QuoteAmount = entity.QuoteAmount;
            quoteResponse.QuoteCcy = entity.QuoteCcy;

            entity.History.ToList().ForEach(x =>
            {
                quoteResponse.History.Add(new HistoryDto() { Rate = x.Value, Timestamp = x.Date });
            });

            return quoteResponse;
        }

        #endregion

    }
}
