using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Services;
using System.Reactive.Linq;
using System;
using Redmine.ViewModels.Interfaces;
using Redmine.Models.Types;

namespace Redmine.ViewModels
{
    public class NewProjectViewModel : ViewModelBase
    {
        private readonly IProjectsService _projectsService;
        private readonly IProjectNavigationService _navigationService;

        public NewProjectViewModel(
            IProjectsService projectsService,
            IProjectNavigationService navigationService)
        {
            _projectsService = projectsService;
            _navigationService = navigationService;
            var canAdd =
               this.WhenAnyValue(x => x.Name)
               .Select((arg) =>
               !string.IsNullOrWhiteSpace(arg));
            AddProjectCommand = ReactiveCommand.CreateFromTask(AddProjectHandlerAsync, canAdd);
        }

        public ICommand AddProjectCommand { get; set; }
        private async Task AddProjectHandlerAsync()
        {
            try
            {
                var project = new Project() { Name = Name };
                await _projectsService.AddProject(project);
                await _navigationService.GoBack();
            }
            catch(Exception ex)
            {

            }
        }

        [Reactive] public string Name { get; set; }
    }
}
