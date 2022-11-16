using FH.Application.History.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        #region Readonly Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public HistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Methods

        [HttpGet("{baseCur}/{exchCur}")]
        public async Task<IActionResult>Get(string baseCur, string exchCur)
        {
            try
            {
                var result = await _mediator.Send(new GetHistoryRequest(baseCur, exchCur));

                if (result == null)
                    return NotFound();

                var returnResult = result.ToList();

                return Ok(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
