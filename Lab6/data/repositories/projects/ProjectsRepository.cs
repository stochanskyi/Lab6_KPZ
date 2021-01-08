using Lab6.data.db.prejectsEF.CodeFirst;
using Lab6.data.db.prejectsEF.CodeFirst.models;
using Lab6.data.db.projects;
using Lab6.data.db.projects.models;
using Lab6.data.db.projectsEF;
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
            return instance ?? (instance = new ProjectsRepository(new db.prejectsEF.CodeFirst.ProjectsCFSourceModel()));
        }

        private IProjectsSourceModel sourceModel;

        private ProjectsRepository(IProjectsSourceModel sourceModel)
        {
            this.sourceModel = sourceModel;
        }

        private IList<models.Project> projects;

        public event Action<IList<models.Project>> ProjectsChangedEvent;

        public void DeleteProject(models.Project project)
        {
            sourceModel.DeleteProject((int)project.Id);

            var index = projects.IndexOfFirst(p => p.Id == project.Id);
            projects.RemoveAt(index);

            ProjectsChangedEvent?.Invoke(projects);
        }
        public IList<models.Project> getProjects()
        {
            projects = sourceModel.GetProjects().Select(dm => parse(dm)).ToList();
            
            return projects;
        }

        public void UpdateProject(models.Project project)
        {
            sourceModel.UpdateProject(toDataModel(project));
            
            var index = projects.IndexOfFirst(p => p.Id == project.Id);
            projects[index] = project;

            ProjectsChangedEvent?.Invoke(projects);
        }

        private ProjectDataModel toDataModel(models.Project project)
        {
            return new ProjectDataModel((int)project.Id, project.Name, project.Budget, project.Description);
        }

        private models.Project parse(ProjectDataModel dataModel)
        {
            return new models.Project(dataModel.Id, dataModel.Name, dataModel.Description, "", dataModel.Budget, models.Project.ProjectStatus.COMPLETED);
        }
    }
}