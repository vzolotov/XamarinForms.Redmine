﻿using System.Threading.Tasks;
using Redmine.Models;

namespace Redmine.ViewModels.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<T>(object data) where T : ViewModelBase;
        Task GoBack();
    }

    public interface IProjectNavigationService : INavigationService
    {

    }

    public interface IIssueNavigationService : INavigationService
    {

    }
    
    public interface ISettingsNavigationService
    {
        Task NavigateTo<T>(T page);
        Task GoBackWithScanData(ScanModel scanModel);
    }
}