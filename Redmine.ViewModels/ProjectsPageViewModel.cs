﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Redmine.Services;
using Redmine.ViewModels.Interfaces;
using Redmine.ViewModels.ItemViewModels;

namespace Redmine.ViewModels
{
    public class ProjectsPageViewModel : ViewModelBase
    {
        private readonly IProjectsService _projectsService;
        private readonly IProjectNavigationService _projectNavigationService;
        private int _limit = 25;
        private int _offset = 0;

        public ProjectsPageViewModel(IProjectsService projectsService, IProjectNavigationService projectNavigationService)
        {
            _projectsService = projectsService;
            _projectNavigationService = projectNavigationService;
            AddCommand = ReactiveCommand.CreateFromTask(AddHandler);
        }

        public ICommand AddCommand { get; set; }

        private Task AddHandler()
        {
            return _projectNavigationService.NavigateToAsync<NewProjectViewModel>(null);
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
