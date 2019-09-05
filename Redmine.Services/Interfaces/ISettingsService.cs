namespace Redmine.Services.Interfaces
{
    public interface ISettingsService
    {
        string Host { get; set; }
        string ApiKey { get; set; }
    }
}
