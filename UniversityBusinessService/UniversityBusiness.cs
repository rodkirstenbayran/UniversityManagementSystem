using UniversityDataService;
using UniversityModel;

namespace UniversityBusinessService
{
    public class UniversityBusiness
    {

        public List<University> GetUniversitiesByType(string type)
        {
            UniversityData universityData = new UniversityData();
            return universityData.GetUniversitiesByType(type);
        }
        public List<University> GetUniversitiesSorted(string sortBy)
        {
            UniversityData universityData = new UniversityData();
            return universityData.GetUniversitiesSorted(sortBy);
        }

        public List<University> GetAllUniversities()
        {
            UniversityData universityData = new UniversityData();

            return universityData.GetUniversity();

        }


        public University GetUniversity(string name, string type, string location, string courses)
        {
            University foundUniversity = new University();

            foreach (var university in GetAllUniversities())
            {
                if (university.name == name && university.type == type && university.location == location && university.courses == courses)
                {
                    foundUniversity = university;
                }
            }

            return foundUniversity;
        }

        public University GetUniversity(string name)
        {
            University foundUniversity = new University();

            foreach (var university in GetAllUniversities())
            {
                if (university.name == name)
                {
                    foundUniversity = university;
                }
            }

            return foundUniversity;
        }


    }
}