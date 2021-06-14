using WebServer.Server.Controllers;
using WebServer.Server.Http;
using WebServer.Models.Animals;

namespace WebServer.Controllers
{
    public class AnimalsController : Controller
    {

        public AnimalsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

            var catAge = query.ContainsKey(ageKey) ? int.Parse(query[ageKey]) : 0;

            var viewModel = new CatViewModel()
            {
                Name = catName,
                Age = catAge
            };
            return View(viewModel);
        }
       
        public HttpResponse Dogs() => View(new DogViewModel
        {
            Name = "Rex",
            Age = 3,
            Breed = "Street perfect"
        });
        public HttpResponse Bunnies() => View("Rabbits");
        public HttpResponse Turtles() => View("Animals/Wild/Turtles");
    }
}
