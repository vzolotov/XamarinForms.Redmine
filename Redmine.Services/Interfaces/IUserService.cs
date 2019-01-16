using System.Threading.Tasks;
using Redmine.Models.Types;

namespace Redmine.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetCurrentUserAsync();
        User CurrentUser { get;}
    }
}