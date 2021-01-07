using Lab5.data.projects;
using Lab5.presentation.mainScreen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var viewModel = ProjectsViewModel.fromDataModels(ProjectsRepository.getInstance().getProjects());
            var window = new MainWindow() { DataContext = viewModel };
            window.Show();
        }
    }
}
