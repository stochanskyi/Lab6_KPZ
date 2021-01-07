using Lab5.presentation.common;
using Lab5.presentation.common.inputView;
using Lab6.data.repositories.projects;
using Lab6.data.repositories.projects.models;
using System;
using System.Windows;
using static Lab6.data.repositories.projects.models.Project;

namespace Lab5.presentation.UserEditScreen
{
    class EditUserViewModel : BaseViewModel
    {
        private IProjectsRepository projectsRepository = ProjectsRepository.getInstance();
        private long projectId;

        public static EditUserViewModel FromDataModel(Project project)
        {
            return new EditUserViewModel()
            {
                projectId = project.Id,
                nameModel = new InputViewModel() { PropertyInput = project.Name },
                descriptionModel = new InputViewModel() { PropertyInput = project.Description },
                custmoerNameModel = new InputViewModel() { PropertyInput = project.CustomerName },
                budgetModel = new InputViewModel() { PropertyInput = project.Budget.ToString() },
                status = project.Status
            };
        }

        private InputViewModel nameModel = new InputViewModel();

        public InputViewModel NameModel
        {
            get => nameModel;
        }

        private InputViewModel descriptionModel = new InputViewModel();

        public InputViewModel DescriptionModel
        {
            get => descriptionModel;
        }

        private InputViewModel custmoerNameModel = new InputViewModel();
        public InputViewModel CustomerNameModel
        {
            get => custmoerNameModel;
        }

        private InputViewModel budgetModel = new InputViewModel();
        public InputViewModel BudgetModel
        {
            get => budgetModel;
        }

        private ProjectStatus status;
        public ProjectStatus Status
        {
            get => status;
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        private ClickCommand confirmCommand;
        public ClickCommand ConfirmCommand
        {
            get
            {
                return confirmCommand ?? (confirmCommand = new ClickCommand(o => OnConfirm(o as Window)));
            }
        }

        private void OnConfirm(Window w)
        {
            w.Close();
            projectsRepository.UpdateProject(new Project(projectId, nameModel.PropertyInput, DescriptionModel.PropertyInput, CustomerNameModel.PropertyInput, float.Parse(BudgetModel.PropertyInput), status));
        }
    }
}
