using SharedTrip.DTOModels.TripModels;
using SharedTrip.DTOModels.UserModels;
using System.Collections.Generic;

namespace SharedTrip.Services.Contracts
{
    public interface IValidator
    {
        public List<string> ValidateUser(UserRegistrationViewModel model);
        public List<string> ValidateTrip(TripCreateViewModel model);
    }
}
