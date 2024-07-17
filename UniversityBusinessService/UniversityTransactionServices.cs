using UniversityDataService;
using UniversityModel;

namespace UniversityBusinessService
{
    public class UniversityTransactionServices
    {
        UniversityValidationService validationServices = new UniversityValidationService();
        UniversityData universityData = new UniversityData();

        public bool CreateUniversity(University university)
        {
            bool result = false;

            if (validationServices.CheckIfUniversityNameExists(university.name))
            {
                result = universityData.AddUniversity(university) > 0;
            }

            return result;
        }

        public bool CreateUniversity(string name, string type, string location, string courses)
        {
            University university = new University { name = name, type = type, location = location, courses = courses };

            return CreateUniversity(university);
        }

        public bool UpdateUniversity(University university)
        {
            bool result = false;

            if (validationServices.CheckIfUniversityNameExists(university.name))
            {
                result = universityData.UpdateUniversity(university) > 0;
            }

            return result;
        }

        public bool UpdateUniversity(string name, string type)
        {
            University university = new University { name = name, type = type };

            return UpdateUniversity(university);
        }

        public bool DeleteUniversity(University university)
        {
            bool result = false;

            if (validationServices.CheckIfUniversityNameExists(university.name))
            {
                result = universityData.DeleteUniversity(university) > 0;
            }

            return result;
        }
    }
}
