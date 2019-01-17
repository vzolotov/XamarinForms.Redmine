using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Redmine.Services;
using Redmine.Services.Interfaces;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    public class ProjectsPageViewModel : ViewModelBase
    {
        private readonly IProjectsService _projectsService;
        private int _limit = 25;
        private int _offset = 0;

        public ProjectsPageViewModel(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        public ObservableCollection<ProjectViewModel> Projects { get; set; } = new ObservableCollection<ProjectViewModel>();

        public override async Task NavigateToAsync(object data)
        {
            IsBusy = true;
            try
            {
                var projects = await _projectsService.GetProjectsAsync();
                _offset += projects.Objects.Count;
                foreach (var item in projects.Objects)
                {
                    Projects.Add(new ProjectViewModel(item, _projectsService));
                }
            }
            catch(Exception ex)
            {

            }
            IsBusy = false;
        }
    }
}
