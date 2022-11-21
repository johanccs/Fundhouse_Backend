using FH.External.External;
using FH.External.Helpers;
using Polly;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace FH.External.ApiRunner
{
    internal sealed class InternalApiRunner
    {
        private readonly InternalApiOptions _options;

        public InternalApiRunner(InternalApiOptions options)
        {
            _options = options;
        }
        internal async Task<string> Run(string baseAddress, string parms = null, bool isQueryParams=false)
        {
            string fullAddress = UrlBuilder.Build(baseAddress,parms, isQueryParams);
            RestClientOptions restOptions = new RestClientOptions(fullAddress)
            {
                ThrowOnAnyError = true,
                MaxTimeout = _options.TimeOut
            };

            RestClient client = new RestClient(restOptions);
            RestRequest request = new RestRequest();

            if (!string.IsNullOrEmpty(_options.ApiKeyName))
            {
                request.AddHeader(_options.ApiKeyName, _options.ApiKeyValue);
            }

            request.Method = Method.Get;

            var retryPolicy = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(_options.MaxRetryAttemps, i => _options.PauseBetweenFailures);

            RestResponse response = new RestResponse();

            await retryPolicy.ExecuteAsync(async () =>
            {
                response = await client.GetAsync(request);
            });

            return response.Content;
          
        }
    }
}
