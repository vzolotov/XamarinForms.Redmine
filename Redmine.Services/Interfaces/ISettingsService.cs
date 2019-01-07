using System;
namespace Redmine.Services
{
    public interface ISettingsService
    {
        string Host { get; set; }
        string ApiKey { get; set; }
    }
}
