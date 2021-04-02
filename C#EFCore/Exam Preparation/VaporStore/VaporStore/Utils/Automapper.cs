using AutoMapper;
using VaporStore;

namespace SoftJail.Utils
{
    public static class Automapper
    {              

        public static IMapper InitializeAutomaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VaporStoreProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
