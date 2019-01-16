using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Redmine.Models.Types;
using Redmine.Services;
using Redmine.Services.Interfaces;

namespace Redmine.ViewModels.ItemViewModels
{
    public class ProjectViewModel : ReactiveObject, IEquatable<ProjectViewModel>
    {
        private readonly IProjectsService _projectsService;

        public ProjectViewModel(Project project, IProjectsService projectsService)
        {
            _projectsService = projectsService;
            Name = project.Name;
            Description = project.Description;
            Id = project.Id;
            Identify = project.Identifier;
            
            DeleteCommand = ReactiveCommand.CreateFromTask(DeleteHandler);
            EditCommand = ReactiveCommand.CreateFromTask(EditHandler);
        }

        private Task EditHandler()
        {
            var project = new Project();
            return _projectsService.EditProject(project);
        }

        private Task DeleteHandler()
        {
            return _projectsService.DeleteProject(Identify);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        [Reactive] public string Description { get; set; }
        [Reactive] public string Name { get; set; }
        [Reactive] public int Id { get; set; }
        [Reactive] public string Identify { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectViewModel);
        }

        public bool Equals(ProjectViewModel other)
        {
            return other != null &&
                   Description == other.Description &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1174144137;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
