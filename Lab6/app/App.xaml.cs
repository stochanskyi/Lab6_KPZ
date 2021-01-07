using Lab5.presentation.mainScreen;
using Lab6.data.repositories.projects;
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
