using System;
using System.Threading.Tasks;
using Redmine.Services;

namespace Redmine.ViewModels
{
    public class ProjectsPageViewModel : ViewModelBase
    {
        private readonly IProjectsService _projectsService;

        public ProjectsPageViewModel(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        public override async Task NavigateToAsync(object data)
        {
            try
            {
                var a = await _projectsService.GetProjectsAsync();
                await base.NavigateToAsync(data);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
