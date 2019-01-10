using System.Threading.Tasks;
using Redmine.Models.Types;

namespace Redmine.Services
{
    public interface IIssueService
    {
        Task<PaginatedObjects<Issue>> GetIssuesAsync(int limit = 25, int offset = 0);
    }
}