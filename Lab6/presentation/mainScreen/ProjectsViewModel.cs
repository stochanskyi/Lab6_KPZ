using Lab5.data.projects;
using Lab5.data.projects.models;
using Lab5.presentation.common;
using Lab5.presentation.UserEditScreen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.presentation.mainScreen
{
    class ProjectsViewModel : BaseViewModel
    {

        private IProjectsRepository projectsRepository = ProjectsRepository.getInstance();

        public static ProjectsViewModel fromDataModels(IList<Project> rojects)
        {
            return new ProjectsViewModel() { projects = new ObservableCollection<Project>(rojects) };
        }

        public IList<Project> toDataModels()
        {
            return projects;
        }
        
        public ProjectsViewModel()
        {
            projectsRepository.ProjectsChangedEvent += (projectss =>
            {
                Projects = new ObservableCollection<Project>(projectss);
            }
            );
        }

        private ObservableCollection<Project> projects;

        public ObservableCollection<Project> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
                NotifyProjectsChanged();
            }
        }

        private ClickCommand deleteProjectCommand;

        public ClickCommand DeleteProjectCommand
        {
            get
            {
                return deleteProjectCommand ??
                    (deleteProjectCommand = new ClickCommand(
                        o => OnDeleteProject(selectedProject),
                        o => selectedProject != null
                        )
                    );
            }
        }

        private ClickCommand modifyProjectCommand;
        public ClickCommand ModifyProjectCommand
        {
            get
            {
                return modifyProjectCommand ?? (modifyProjectCommand = new ClickCommand(
                    o => OnModigyProject(selectedProject),
                    o => selectedProject != null
                    )
                );
            }
        }


        private void OnDeleteProject(Project project)
        {
            projectsRepository.DeleteProject(project);
        }

        private void OnModigyProject(Project project)
        {
            var vm = EditUserViewModel.FromDataModel(project);
            var window = new EditUser { DataContext = vm };
            window.Show();
        }

        private Project selectedProject;

        public Project SelectedProject
        {
            get
            {
                return selectedProject;
            }
            set
            {
                selectedProject = value;
            }
        }

        private void NotifyProjectsChanged()
        {
            NotifyPropertyChanged("Projects");
        }

    }
}