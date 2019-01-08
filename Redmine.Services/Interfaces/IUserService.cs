using System.Threading.Tasks;
using Redmine.Net.Api.Types;

namespace Redmine.Services
{
    public interface IUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}