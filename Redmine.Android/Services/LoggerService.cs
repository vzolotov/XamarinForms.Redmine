using System;
using Android.Util;
using Redmine.Models;
using Redmine.Services.Interfaces;

namespace Redmine.Droid.Services
{
    public class LoggerService : ILoggerService
    {
        string Tag { get; set; } = "";

        Severity Severity { get; set; } = Severity.All;

        public  void Init(string tag, Severity severity = Severity.All)
        {
            Tag = tag;
            Severity = severity;
        }

        public void Verbose(string message) => Verbose(message, Tag);

        public void Verbose(string message, string tag)
        {
            if ((Severity & Severity.Verbose) == Severity.Verbose)
            {
                Log.Verbose(tag, message);
            }
        }

        public void Debug(string message) => Debug(message, Tag);

        public void Debug(string message, string tag)
        {
            if ((Severity & Severity.Debug) == Severity.Debug)
            {
                Log.Debug(tag, message);
            }
        }

        public void Info(string message) => Info(message, Tag);

        public void Info(string message, string tag)
        {
            if ((Severity & Severity.Info) == Severity.Info)
            {
                Log.Info(tag, message);
            }
        }

        public void Warning(string message, Exception exception = null) => Warning(message, Tag, exception);

        public void Warning(string message, string tag, Exception exception = null)
        {
            if ((Severity & Severity.Warning) != Severity.Warning) return;
            if (exception != null)
            {
                Log.Warn(tag, Java.Lang.Throwable.FromException(exception), message);
            }
            else
            {
                Log.Warn(tag, message);
            }
        }

        public void Error(string message, Exception exception = null) => Error(message, Tag, exception);

        public void Error(string message, string tag, Exception exception = null)
        {
            if ((Severity & Severity.Error) != Severity.Error) return;
            if (exception != null)
            {
                Log.Error(tag, Java.Lang.Throwable.FromException(exception), message);
            }
            else
            {
                Log.Error(tag, message);
            }
        }
    }
}