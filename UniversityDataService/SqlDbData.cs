using UniversityModel;
using System.Data.SqlClient;

namespace UniversityDataService
{
    public class SqlDbData
    {

        string connectionString
       // = "Data Source = DESKTOP-EO8PNHF\\SQLEXPRESS; Initial Catalog = UniversityManagement; Integrated Security = True;";
        = "Server=tcp:20.212.248.41,1433;Database=UniversityManagement;User Id=sa;Password=rkb1104!";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<University> GetUniversitiesByType(string type)
        {
            string selectStatement = "SELECT name, type, location, courses FROM universities WHERE type = @type";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@type", type);

            sqlConnection.Open();
            List<University> universities = new List<University>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string universityType = reader["type"].ToString();
                string location = reader["location"].ToString();
                string courses = reader["courses"].ToString();

                University university = new University
                {
                    name = name,
                    type = universityType,
                    location = location,
                    courses = courses
                };

                universities.Add(university);
            }

            sqlConnection.Close();
            return universities;
        }

        public List<University> GetUniversitiesSorted(string sortBy)
        {
            string selectStatement = $"SELECT name, type, location, courses FROM universities ORDER BY {sortBy}";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<University> universities = new List<University>();
            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string universityType = reader["type"].ToString();
                string location = reader["location"].ToString();
                string courses = reader["courses"].ToString();

                University university = new University
                {
                    name = name,
                    type = universityType,
                    location = location,
                    courses = courses
                };

                universities.Add(university);
            }

            sqlConnection.Close();
            return universities;
        }

        public List<University> GetUniversity()
        {
            string selectStatement = "SELECT name, type, location, courses FROM universities";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<University> university = new List<University>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["name"].ToString();
                string type = reader["type"].ToString();
                string location = reader["location"].ToString();
                string courses = reader["courses"].ToString();

                University readUniversity = new University();
                readUniversity.name = name;
                readUniversity.type = type;
                readUniversity.location = location;
                readUniversity.courses = courses;

                university.Add(readUniversity);
            }

            sqlConnection.Close();

            return university;
        }

        public int AddUniversity(string name, string type, string location, string courses)
        {
            int success;

            string insertStatement = "INSERT INTO universities VALUES (@name, @type, @location, @courses)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@type", type);
            insertCommand.Parameters.AddWithValue("@location", location);
            insertCommand.Parameters.AddWithValue("@courses", courses);

            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUniversity(string name, string type)
        {
            int success;

            string updateStatement = $"UPDATE universities SET type = @Type WHERE name = @name";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Type", type);
            updateCommand.Parameters.AddWithValue("@name", name);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUniversity(string name)
        {
            int success;

            string deleteStatement = $"DELETE FROM universities WHERE name = @name";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@name", name);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}
