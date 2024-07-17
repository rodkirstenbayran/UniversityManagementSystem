using UniversityBusinessService;
using Microsoft.AspNetCore.Mvc;

namespace UniversityManagement.API.Controllers
{
    [ApiController]
    [Route("api/university")]
    public class UniversityController : Controller
    {
        UniversityBusiness _universityGetServices;
        UniversityTransactionServices _universityTransactionServices;

        public UniversityController()
        {
            _universityGetServices = new UniversityBusiness();
            _universityTransactionServices = new UniversityTransactionServices();
        }

        [HttpGet]
        public IEnumerable<UniversityManagement.API.University> GetUniversity()
        {
            var activeuniversity = _universityGetServices.GetAllUniversities();

            List<UniversityManagement.API.University> university = new List<University>();

            foreach (var item in activeuniversity)
            {
                university.Add(new API.University { name = item.name, type = item.type, location = item.location, courses = item.courses });
            }

            return university;
        }

        [HttpPost]
        public JsonResult AddUniversity(University request)
        {
            var result = _universityTransactionServices.CreateUniversity(request.name, request.type, request.location, request. courses);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUniversity(University request)
        {
            var result = _universityTransactionServices.UpdateUniversity(request.name, request.type);

            return new JsonResult(result);
        }


        [HttpDelete]
        public JsonResult DeleteUniversity(University request)
        {
            var result = _universityTransactionServices.DeleteUniversity(new UniversityModel.University
            {
                name = request.name,
                type = request.type,
                location = request.location,
                courses = request.courses
            });

            return new JsonResult(result);
        }

    }
}
