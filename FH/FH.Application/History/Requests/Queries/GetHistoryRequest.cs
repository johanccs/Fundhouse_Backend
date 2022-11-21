using MediatR;
using System.Collections.Generic;

namespace FH.Application.History.Requests.Queries
{
    public sealed class GetHistoryRequest: IRequest<IEnumerable<Domain.DbModels.History>>
    {
        public string BaseCurrency { get; set; }
        public string ExchangeCurrency { get; set; }

        public GetHistoryRequest(string baseCur, string exchCur)
        {
            BaseCurrency = baseCur;
            ExchangeCurrency = exchCur;
        }
    }
}
