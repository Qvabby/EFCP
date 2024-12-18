using AutoMapper;
using EFCP.Data;
using EFCP.models.Dtos;
using EFCP.models;
using EFCP.Services;

namespace EFCP
{
    //EFCP - Entity Framework Core Practice
    public class Program
    {
        static void Main(string[] args)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                //cfg.CreateMap<List<User>, List<UserDto>>().ReverseMap();
            });

            var mapper = new Mapper(mappingConfig);
            EFCPDbContext db = new EFCPDbContext();
            UserService userService = new UserService(db, mapper);

            var user = new UserDto
            {
                Name = "Jemali",
                Lastname = "Salukvadze",
                Age = 18,
                Email = "Saluqvadze2006@gmail.com"
            };

            //userService.AddUser(user);
            //userService.DeleteUser(1);
            //userService.UpdateUser(user, 2);
        }
    }
}
