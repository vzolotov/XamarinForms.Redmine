using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Foundation;
using Redmine.Models;
using Redmine.Services.Interfaces;

namespace Redmine.iOS.Services
{
    public class LoggerService : ILoggerService
    {
        private string Tag { get; } = AppConstants.LoggerTag;

        Severity Severity { get; set; } = Severity.All;

        public void Verbose(string message) => Verbose(message, Tag);

        public void Verbose(string message, string tag)
        {
            if ((Severity & Severity.Verbose) == Severity.Verbose)
            {
                Write(message, tag);
            }
        }

        public void Debug(string message) => Debug(message, Tag);

        public void Debug(string message, string tag)
        {
            if ((Severity & Severity.Debug) == Severity.Debug)
            {
                Write(message, tag);
            }
        }

        public void Info(string message) => Info(message, Tag);

        public void Info(string message, string tag)
        {
            if ((Severity & Severity.Info) == Severity.Info)
            {
                Write(message, tag);
            }
        }

        public void Warning(string message, Exception exception = null) =>
            Warning(message, Tag, exception);

        public void Warning(string message, string tag, Exception exception = null)
        {
            if ((Severity & Severity.Warning) == Severity.Warning)
            {
                Write(message, tag, exception);
            }
        }

        public void Error(string message, Exception exception = null) =>
            Error(message, Tag, exception);

        public void Error(string message, string tag, Exception exception = null)
        {
            if ((Severity & Severity.Error) == Severity.Error)
            {
                Write(message, tag, exception);
            }
        }

        public void Write(string message, string tag, Exception exception = null,
            [CallerMemberName] string severity = "")
        {
            tag = string.IsNullOrWhiteSpace(tag) ? "" : $"{tag}: ";
            severity = severity.Substring("".Length);
            var str = $"{tag}{severity}: {message}";
            if (exception != null)
            {
                str = $"{str}\n{exception.Message}";
            }

            using (var nsstr = new NSString(str))
            {
                NSLog(nsstr.Handle);
            }
        }

        [DllImport(ObjCRuntime.Constants.FoundationLibrary)]
        private static extern void NSLog(IntPtr message);
    }
}