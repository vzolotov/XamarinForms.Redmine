using Redmine.Net.Api;

namespace Redmine.Services.Interfaces
{
    public interface IRedmineService
    {
        RedmineManager GetRedmineManager();
    }
}