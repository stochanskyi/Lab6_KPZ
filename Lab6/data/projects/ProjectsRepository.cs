using Lab5.data.projects.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.data.projects
{
    public class ProjectsRepository : IProjectsRepository
    {

        private static ProjectsRepository instance = null;

        public static ProjectsRepository getInstance()
        {
            return instance ?? (instance = new ProjectsRepository());
        }

        private ProjectsRepository()
        {

        }

        private IList<Project> projects = new List<Project>()
        {
            new Project(
                1,
                "Apolon",
                "Space shuttle control project",
                "Mark Turner",
                3000,
                Project.ProjectStatus.PENDING
                ),
            new Project(
                2,
                "Stello",
                "Music sonunds editor",
                "Hannah Davidson",
                40000,
                Project.ProjectStatus.IN_PROGRESS
                ),
            new Project(
                4,
                "Setonera",
                "Mobile video editor",
                "Ronald Wayne",
                80000,
                Project.ProjectStatus.IN_PROGRESS
                ),
            new Project(
                5,
                "Jenk",
                "Some description should be here",
                "Robert Martinez",
                700000,
                Project.ProjectStatus.PENDING
                ),
            new Project(
                1,
                "Danesk",
                "Some description should be here",
                "Devid Lineer",
                1230000,
                Project.ProjectStatus.PENDING
                ),
        };

        public event Action<IList<Project>> ProjectsChangedEvent;

        public void DeleteProject(Project project)
        {
            var index = projects.IndexOfFirst(p => p.Id == project.Id);
            projects.RemoveAt(index);
            ProjectsChangedEvent?.Invoke(projects);
        }

        public DetailedProject getProjectDetails(long id)
        {
            throw new NotImplementedException();
        }

        public IList<Project> getProjects()
        {
            return projects;
        }

        public void UpdateProject(Project project)
        {
            var projectToUpdate = projects.FirstOrDefault(projects => projects.Id == project.Id);
            if (projectToUpdate == null) return;

            var indexToUpdate = projects.IndexOf(projectToUpdate);

            if (indexToUpdate < 0) return;

            projects[indexToUpdate] = project;

            ProjectsChangedEvent?.Invoke(projects);
        }

    }
}