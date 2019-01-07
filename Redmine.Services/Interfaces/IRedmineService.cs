using Redmine.Net.Api;

namespace Redmine.Services.NetworkServices
{
    public interface IRedmineService
    {
        RedmineManager GetRedmineManager();
    }
}