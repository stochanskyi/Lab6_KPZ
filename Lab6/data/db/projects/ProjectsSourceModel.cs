using Lab6.data.db.projects.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.data.db.projects
{
    class ProjectsSourceModel : IProjectsSourceModel
    {

        public void DeleteProject(int id)
        {
            var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("DELETE FROM Projects WHERE project_id = " + id, connection);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public IList<ProjectDataModel> GetProjects()
        {
            var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("SELECT project_id, project_name, budget, description FROM Projects", connection);

            var dataReader = command.ExecuteReader();

            List<ProjectDataModel> prohects = new List<ProjectDataModel>();

            while (dataReader.Read())
            {
                prohects.Add(new ProjectDataModel(dataReader.GetInt32(0), dataReader.GetString(1), (float)dataReader.GetDecimal(2), dataReader.IsDBNull(3) ? null : dataReader.GetString(3)));
            }

            connection.Close();

            return prohects;
        }

        public void InsertProject(ProjectDataModel project)
        {
            var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("INSERT INTO Projects (project_name, budget, description) " +
                $"VALUES({project.Name}, {project.Budget}, {project.Description})", connection);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateProject(ProjectDataModel project)
        {
            var connection = GetConnection();
            connection.Open();

            string commandString = "UPDATE Projects " +
                $"SET project_name = @PName, budget = @PBudg, description = @PDesc\n" +
                $"WHERE project_id = @ID";

            var command = new SqlCommand(commandString, connection);

            command.Parameters.Add("@PName", System.Data.SqlDbType.NVarChar);
            command.Parameters["@PName"].Value = project.Name;


            command.Parameters.Add("@PBudg", System.Data.SqlDbType.Decimal);
            command.Parameters["@PBudg"].Value = project.Budget;


            command.Parameters.Add("@PDesc", System.Data.SqlDbType.NVarChar);
            command.Parameters["@PDesc"].Value = project.Description ?? SqlString.Null;

            command.Parameters.Add("@ID", System.Data.SqlDbType.Int);
            command.Parameters["@ID"].Value = project.Id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        private SqlConnection GetConnection()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-59EBKJC;Initial Catalog=CompanyManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return connection;
        }
    }
}