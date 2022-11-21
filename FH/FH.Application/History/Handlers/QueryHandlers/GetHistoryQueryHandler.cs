using FH.Application.History.Requests.Queries;
using FH.Services.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FH.Application.History.Handlers.QueryHandlers
{
    public sealed class GetHistoryQueryHandler : IRequestHandler<GetHistoryRequest, IEnumerable<Domain.DbModels.History>>
    {
        #region Readonly Fields

        private readonly IHistoryRepo _historyRepo;

        #endregion

        #region  Ctor

        public GetHistoryQueryHandler(IHistoryRepo historyRepo)
        {
            _historyRepo = historyRepo;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Domain.DbModels.History>> Handle(GetHistoryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.DbModels.History>result = await _historyRepo.GetHistoryByCurrencyCode(request.BaseCurrency, request.ExchangeCurrency);
            
            return result;
        }

        #endregion

    }
}
