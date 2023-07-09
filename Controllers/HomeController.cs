using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
           
        {
            List<Database> data = ReadPropertiesFromFile("Database.txt");
            var mostpicks = data.Where(p=>p.Popularity == "Most picks").ToList();
            var first_mostpick = mostpicks.FirstOrDefault();
            var beautybackyard = data.Where( p => p.Description == "beauty backyard").ToList();
            var _beautybackyard = beautybackyard.FirstOrDefault();
            var livingroom = data.Where(p => p.Description == "living room").ToList();
            var apartment = data.Where(p => p.Description == "Apartment").ToList();
            ViewData["mostpicks"] = mostpicks;
            ViewData["first_mostpicks"]= first_mostpick;
            ViewData["beautybackyard"] = beautybackyard;
            ViewData["livingroom"] = livingroom;
            ViewData["apartment"]= apartment;



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public static List<Database> ReadPropertiesFromFile(string filepath)
        {
            List<Database> data = new List<Database>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split('|');
                        if(fields.Length >= 8)
                        {
                            string name = fields[1].Trim();
                            string city = fields[2].Trim();
                            string location = fields[3].Trim();
                            string price = fields[4].Trim();
                            string description = fields[5].Trim();
                            string type = fields[6].Trim();
                            string popularity = fields[7].Trim();
                            bool ispopular = bool.Parse(fields[8].Trim());

                            Database database = new Database (name, city, location, price, description, type, popularity, ispopular);
                            data.Add (database);
                        }

                    }
                }

            }
            return data;

        }
        
    }
}