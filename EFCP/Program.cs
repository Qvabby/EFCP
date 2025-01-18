using AutoMapper;
using EFCP.Data;
using EFCP.models.Dtos;
using EFCP.models;
using EFCP.Services;
using qvabbytesD1;

namespace EFCP
{
    //EFCP - Entity Framework Core Practice
    public class Program
    {
        static async Task Main(string[] args)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });

            var mapper = new Mapper(mappingConfig);
            EFCPDbContext db = new EFCPDbContext();
            UserService userService = new UserService(db, mapper);


            MenuService menuService = new MenuService();
            menuService.Menu();



            //var user = new UserDto
            //{
            //    Name = "Jemali2",
            //    Lastname = "Salukvadze",
            //    Age = 18,
            //    Email = "Saluqvadze2006@gmail.com"
            //};

            //await userService.AddUserAsync(user);
            //await userService.DeleteUserAsync(2);
            //await userService.UpdateUserAsync(user, 2);
        }
    }
}
