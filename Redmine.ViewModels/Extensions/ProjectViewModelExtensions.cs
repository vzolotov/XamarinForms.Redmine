using AutoMapper;
using Redmine.Models.Types;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels.Extensions
{
    public static class ProjectViewModelExtensions
    {
        public static Project ToProject(this ProjectViewModel project)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<ProjectViewModel, Project>());
            return config.CreateMapper().Map<Project>(project);
        }
        
        public static ProjectViewModel ToProjectViewModel(this Project project)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Project, ProjectViewModel>());
            return config.CreateMapper().Map<ProjectViewModel>(project);
        }
    }
}