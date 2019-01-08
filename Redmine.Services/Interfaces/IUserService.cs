using System.Threading.Tasks;
using Redmine.Models.Types;

namespace Redmine.Services
{
    public interface IUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}