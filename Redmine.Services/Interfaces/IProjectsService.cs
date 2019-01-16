using System.Threading.Tasks;
using Redmine.Models.Types;

namespace Redmine.Services.Interfaces
{
    public interface IProjectsService
    {
        Task<PaginatedObjects<Project>> GetProjectsAsync();
        Task DeleteProject(string id);

        Task EditProject(Project project);
    }
}