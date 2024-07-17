using UniversityModel;

namespace UniversityDataService
{
    public class UniversityData
    {
        List<University> university;
        SqlDbData sqlData;
        public UniversityData()
        {
            university = new List<University>();
            sqlData = new SqlDbData();
        }

        public List<University> GetUniversitiesByType(string type)
        {
            return sqlData.GetUniversitiesByType(type);
        }


        public List<University> GetUniversitiesSorted(string sortBy)
        {
            return sqlData.GetUniversitiesSorted(sortBy);
        }

        public List<University> GetUniversity()
        {
            university = sqlData.GetUniversity();
            return university;
        }

        public int AddUniversity(University university)
        {
            return sqlData.AddUniversity(university.name, university.type, university.location, university.courses);
        }

        public int UpdateUniversity(University university)
        {
            return sqlData.UpdateUniversity(university.name, university.type);
        }

        public int DeleteUniversity(University university)
        {
            return sqlData.DeleteUniversity(university.name);
        }


    }
}
