using System.Threading.Tasks;
using Redmine.Models.Types;

namespace Redmine.Services
{
    public interface IProjectsService
    {
        Task AddProject(Project project);
        Task DeleteProject(string id);
        Task EditProject(Project project);
        Task<PaginatedObjects<Project>> GetProjectsAsync();
    }
}