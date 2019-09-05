using System;

namespace Redmine.Services.Interfaces
{
    public interface ILoggerService
    {
        void Verbose(string message);
        void Verbose(string message, string tag);

        void Debug(string message);
        void Debug(string message, string tag);

        void Info(string message);
        void Info(string message, string tag);

        void Warning(string message, Exception exception = null);
        void Warning(string message, string tag, Exception exception = null);

        void Error(string message, Exception exception = null);
        void Error(string message, string tag, Exception exception = null);

    }
}
