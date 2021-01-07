using Lab6.data.db.projects;
using Lab6.data.db.projects.models;
using Lab6.data.repositories.projects.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace  Lab6.data.repositories.projects
{
    public class ProjectsRepository : IProjectsRepository
    {
        private static ProjectsRepository instance = null;

        public static ProjectsRepository getInstance()
        {
            //TODO REPLACE WITH DEPENDENCY INJECTION
            return instance ?? (instance = new ProjectsRepository(new ProjectsSourceModel()));
        }

        private IProjectsSourceModel sourceModel;

        private ProjectsRepository(IProjectsSourceModel sourceModel)
        {
            this.sourceModel = sourceModel;
        }

        private IList<Project> projects;

        public event Action<IList<Project>> ProjectsChangedEvent;

        public void DeleteProject(Project project)
        {
            sourceModel.DeleteProject((int)project.Id);

            var index = projects.IndexOfFirst(p => p.Id == project.Id);
            projects.RemoveAt(index);

            ProjectsChangedEvent?.Invoke(projects);
        }
        public IList<Project> getProjects()
        {
            projects = sourceModel.GetProjects().Select(dm => parse(dm)).ToList();
            
            return projects;
        }

        public void UpdateProject(Project project)
        {
            sourceModel.UpdateProject(toDataModel(project));
            
            var index = projects.IndexOfFirst(p => p.Id == project.Id);
            projects[index] = project;

            ProjectsChangedEvent?.Invoke(projects);
        }

        private ProjectDataModel toDataModel(Project project)
        {
            return new ProjectDataModel((int)project.Id, project.Name, project.Budget, project.Description);
        }

        private Project parse(ProjectDataModel dataModel)
        {
            return new Project(dataModel.Id, dataModel.Name, dataModel.Description, "", dataModel.Budget, Project.ProjectStatus.COMPLETED);
        }
    }
}