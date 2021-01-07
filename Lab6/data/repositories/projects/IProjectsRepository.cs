using Lab6.data.repositories.projects.models;
using System;
using System.Collections.Generic;

namespace Lab6.data.repositories.projects
{
    interface IProjectsRepository
    {
        event Action<IList<Project>> ProjectsChangedEvent;

        IList<Project> getProjects();

        DetailedProject getProjectDetails(long id);

        void DeleteProject(Project project);

        void UpdateProject(Project project);
    }
}
