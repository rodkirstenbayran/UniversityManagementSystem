using UniversityDataService;
using UniversityModel;
using UniversityBusinessService;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to University Find!");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Display Universities");
                Console.WriteLine("2. Search for Universities (by type)");
                Console.WriteLine("3. Sort Universities");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nListed Universities:");
                        DisplayUniversities();
                        Console.WriteLine("---------------------------");
                        break;
                    case "2":
                        Console.Write("\nEnter the type of universities to search: ");
                        string type = Console.ReadLine();
                        Console.WriteLine($"\nUniversities of type {type}:");
                        SearchUniversitiesByType(type);
                        Console.WriteLine("---------------------------");
                        break;
                    case "3":
                        Console.Write("\nEnter the criteria to sort universities by (name, type, location): ");
                        string sortBy = Console.ReadLine();
                        if (sortBy.Equals("name", StringComparison.OrdinalIgnoreCase) || sortBy.Equals("type", StringComparison.OrdinalIgnoreCase) || sortBy.Equals("location", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"\nUniversities sorted by {sortBy}:");
                            SortUniversities(sortBy);
                            Console.WriteLine("---------------------------");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid criteria. Please enter 'name', 'type', or 'location'.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("\nExiting program...");
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }
        }
        static void DisplayUniversities()
        {
            UniversityBusiness universityService = new UniversityBusiness();
            var universities = universityService.GetAllUniversities();

            foreach (var university in universities)
            {
                Console.WriteLine($"\nName: {university.name}");
                Console.WriteLine($"    - Type: {university.type}");
                Console.WriteLine($"    - Location: {university.location}");
                Console.WriteLine("    - Courses:");
                string[] courses = university.courses.Split(',');
                foreach (var course in courses)
                {
                    Console.WriteLine($"        {course.Trim()}");
                }
            }
        }

        static void SearchUniversitiesByType(string type)
        {
            UniversityBusiness universityService = new UniversityBusiness();
            var universities = universityService.GetUniversitiesByType(type);

            if (universities.Count == 0)
            {
                Console.WriteLine($"No universities found with type {type}.");
                return;
            }

            foreach (var university in universities)
            {
                Console.WriteLine($"\nName: {university.name}");
                Console.WriteLine($"    - Type: {university.type}");
                Console.WriteLine($"    - Location: {university.location}");
                Console.WriteLine("    - Courses:");
                string[] courses = university.courses.Split(',');
                foreach (var course in courses)
                {
                    Console.WriteLine($"        {course.Trim()}");
                }
            }
        }

        static void SortUniversities(string sortBy)
        {
            UniversityBusiness universityService = new UniversityBusiness();
            var universities = universityService.GetUniversitiesSorted(sortBy);

            if (universities.Count == 0)
            {
                Console.WriteLine($"No universities found to sort by {sortBy}.");
                return;
            }

            foreach (var university in universities)
            {
                Console.WriteLine($"\nName: {university.name}");
                Console.WriteLine($"    - Type: {university.type}");
                Console.WriteLine($"    - Location: {university.location}");
                Console.WriteLine("    - Courses:");
                string[] courses = university.courses.Split(',');
                foreach (var course in courses)
                {
                    Console.WriteLine($"        {course.Trim()}");
                }
            }
        }

    }
}



