using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using SharedTrip.DTOModels.TripModels;
using SharedTrip.DTOModels.UserModels;
using SharedTrip.Services.Contracts;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public List<string> ValidateUser(UserRegistrationViewModel userDTO)
        {
            var result = new List<string>();

            if (userDTO.Username.Length < 5 || userDTO.Username.Length > 20)
            {
                result.Add("Ivalid username input.");
            }

            if (!Regex.IsMatch(userDTO.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                result.Add("Invalid email address input");
            }

            if (userDTO.Password.Length < 6 || userDTO.Password.Length > 20)
            {
                result.Add("Invalid password input");
            }

            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                result.Add("Password input dose not match confirmation password!");
            }

            return result;
        }

        public List<string> ValidateTrip(TripCreateViewModel model)
        {
            var result = new List<string>();

            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None, out var time))
            {
                result.Add("Invalid DateTime Format");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                result.Add("Invalid number of seats. Seats must be in range of 2 to 6.");
            }

            if (model.Description.Length > 80)
            {
                result.Add("Description is too long. It must be up to 80 characters.");
            }

            return result;
        }
    }
}
//"dd.MM.yyyy HH:mm"