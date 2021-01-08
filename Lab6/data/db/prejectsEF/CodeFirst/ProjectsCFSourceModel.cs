using Lab6.data.db.projects;
using Lab6.data.db.projects.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.data.db.prejectsEF.CodeFirst
{
    class ProjectsCFSourceModel : IProjectsSourceModel
    {

        private ProjectsDatabaseContext dbContext = new ProjectsDatabaseContext();

        public ProjectsCFSourceModel()
        {
            dbContext.Database.Initialize(true);
        }

        public void DeleteProject(int id)
        {
            var projectToDelete = dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (projectToDelete == null) return;

            dbContext.Projects.Remove(projectToDelete);
            dbContext.SaveChanges();
        }

        public IList<ProjectDataModel> GetProjects()
        {
            return dbContext.Projects.ToList().Select(p => new ProjectDataModel(p.Id, p.Name, (float)p.Budget, p.Description)).ToList();
        }

        public void InsertProject(ProjectDataModel project)
        {
            //TODO
        }

        public void UpdateProject(ProjectDataModel project)
        {
            var projectToUpdate = dbContext.Projects.FirstOrDefault(p => p.Id == project.Id);
            if (projectToUpdate == null) return;

            projectToUpdate.Name = project.Name;
            projectToUpdate.Budget = (decimal)project.Budget;
            projectToUpdate.Description = project.Description;

            dbContext.SaveChanges();
        }
    }
}
