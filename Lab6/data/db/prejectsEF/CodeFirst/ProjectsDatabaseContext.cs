﻿using System.Data.Entity;

namespace Lab6.data.db.prejectsEF.CodeFirst
{
    class ProjectsDatabaseContext : DbContext
    {
        public ProjectsDatabaseContext() : base("CompanyManagementLab6")
        {
        }
        public DbSet<models.Project> Projects { get; set; }
    }
}
