using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.data.projects.models
{
    public class Project
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CustomerName { get; set; }
        public float Budget { get; set; }

        public ProjectStatus Status { get; set; }

        public Project(Project project)
            : this(
                  project.Id,
                  project.Name,
                  project.Description,
                  project.CustomerName,
                  project.Budget,
                  project.Status
                  )
        {
        }

        public Project(
            long Id,
            string Name,
            string Description,
            string CustomerName,
            float Budget,
            ProjectStatus status
            )
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.CustomerName = CustomerName;
            this.Budget = Budget;
            this.Status = Status;
        }

        public enum ProjectStatus
        {
            PENDING,
            WAITING,
            IN_PROGRESS,
            COMPLETED,
            VERIFIED
        }

        public Project Clone()
        {
            return new Project(Id, Name, Description, CustomerName, Budget, Status);
        }
    }
}