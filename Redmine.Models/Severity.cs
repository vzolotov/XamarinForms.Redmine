using System;

namespace Redmine.Models
{
    [Flags]
    public enum Severity
    {
        None = 0,
        Verbose = 1,
        Debug = 2,
        Info = 4,
        Warning = 8,
        Error = 16,
        All = Verbose | Debug | Info | Warning | Error,
    }
}