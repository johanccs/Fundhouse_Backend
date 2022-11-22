using FH.Application.Common.Abstractions;
using System;

namespace FH.Tests.Services.MockServices
{
    public class MockLoggerManager : ILoggerService
    {
        public void LogDebug(string message) => Console.WriteLine(message);

        public void LogError(string message) => Console.WriteLine(message);
       
        public void LogInfo(string message) => Console.WriteLine(message);

        public void LogWarn(string message) => Console.WriteLine(message);

    }
}
