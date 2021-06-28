using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.DTOModels.UserModels;
using SharedTrip.Services;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly Validator validator;
        private readonly UserService userService;

        public UsersController(Validator validator, UserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }


        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            var userId = userService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegistrationViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            var validationResult = this.validator.ValidateUser(model);

            if (validationResult.Any())
            {
                return Redirect("/Users/Register");
            }

            userService.CreateUser(model.Username, model.Email, model.Password);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
