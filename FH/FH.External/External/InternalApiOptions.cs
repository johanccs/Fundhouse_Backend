using System;

namespace FH.External.External
{
    public sealed class InternalApiOptions
    {
        internal int TimeOut { get; set; } = 3000;
        internal string ApiKeyName { get; set; }
        internal string ApiKeyValue { get; set; }
        internal int MaxRetryAttemps { get; set; } = 3;
        internal TimeSpan PauseBetweenFailures { get; set; } = TimeSpan.FromSeconds(2);
    }
}
