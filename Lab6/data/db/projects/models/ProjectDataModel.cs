
namespace Lab6.data.db.projects.models
{
    class ProjectDataModel
    {
        public int Id { get; }
        public string Name { get; }
        public float Budget { get; }
        public string Description { get; }

        public ProjectDataModel(int Id, string Name, float Budget, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Budget = Budget;
            this.Description = Description;
        }

    }
}
