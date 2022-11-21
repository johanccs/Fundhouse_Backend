namespace FH.External.Helpers
{
    internal static class UrlBuilder
    {
        internal static string Build(string baseUrl, string parms, bool isQueryParams)
        {
            if (string.IsNullOrEmpty(parms))
                return baseUrl;
            if(isQueryParams)
                return $"{baseUrl}?{parms}";
            else
            return $"{baseUrl}/{parms}";
        }
    }
}
