using Lab6.data.db.prejectsEF;
using Lab6.data.db.projects;
using Lab6.data.db.projects.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.data.db.projectsEF
{
    class ProjectsEfSourceModel : IProjectsSourceModel
    {

        private CompanyManagementEntities dao = new CompanyManagementEntities();

        public void DeleteProject(int id)
        {
            var projectToRemove = dao.Projects.FirstOrDefault(p => p.project_id == id);
            if (projectToRemove == null) return;

            dao.Projects.Remove(projectToRemove);
            dao.SaveChanges();
        }

        public IList<ProjectDataModel> GetProjects()
        {
            return dao.Projects.ToList().Select(p => new ProjectDataModel(p.project_id, p.project_name, (float)p.budget, p.description)).ToList();
        }

        public void InsertProject(ProjectDataModel project)
        {
            //TODO
        }

        public void UpdateProject(ProjectDataModel project)
        {
            var projectToUpdate = dao.Projects.FirstOrDefault(p => p.project_id == project.Id);
            if (project == null) return;

            projectToUpdate.project_name = project.Name;
            projectToUpdate.budget = (decimal)project.Budget;
            projectToUpdate.description = project.Description;

            dao.SaveChanges();

        }
    }
}
