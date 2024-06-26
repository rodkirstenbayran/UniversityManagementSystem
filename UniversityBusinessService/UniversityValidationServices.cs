namespace UniversityBusinessService
{
    public class UniversityValidationService
    {

        UniversityBusiness getServices = new UniversityBusiness();

        public bool CheckIfUniversityNameExists(string name)
        {
            bool result = getServices.GetUniversity(name) != null;
            return result;
        }

        public bool CheckIfUniversityNameExists(string name, string type, string location, string courses)
        {
            bool result = getServices.GetUniversity(name, type, location, courses) != null;
            return result;
        }

    }
}
