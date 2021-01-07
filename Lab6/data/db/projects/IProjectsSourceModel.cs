using Lab6.data.db.projects.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.data.db.projects
{
    interface IProjectsSourceModel
    {
        IList<ProjectDataModel> GetProjects();

        void DeleteProject(int id);

        void InsertProject(ProjectDataModel project);

        void UpdateProject(ProjectDataModel project);
    }
}