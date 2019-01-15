using System.Collections.Generic;
using System.Threading.Tasks;
using Redmine.Models.Types;

namespace Redmine.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
    }
}