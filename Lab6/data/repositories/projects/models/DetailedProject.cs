using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.data.repositories.projects.models
{
    public class DetailedProject : Project
    {
        public IList<ProjectPhase> phases { get; set; }

        DetailedProject(Project project, IList<ProjectPhase> phases)
        : base(project)
        {
            this.phases = phases;
        }
    }
}
