using AutoMapper;
using EFCP.Data;
using EFCP.models.Dtos;
using EFCP.models;
using EFCP.Services;
using qvabbytesD1;
using EFCP.Interfaces;

namespace EFCP
{
    //EFCP - Entity Framework Core Practice
    public class Program
    {
        /*
                Classes and Objects X
                Structs
                Object-Oriented Programming X
                Interfaces X
                Inheritance X
                Abstract Classes X
                Type Conversions X
                Generics
                Iterators
                Collections X
                Delegates & Lambdas X
                Events
                LINQ X
                Stream API
                File System API
             */

        static async Task Main(string[] args)
        {
            //Mapping Configuration
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });
            //Mapper
            var mapper = new Mapper(mappingConfig);
            //DBContext
            EFCPDbContext db = new EFCPDbContext();
            //---------------- Services -----------------
            //UserService
            IUserService userService = new UserService(db, mapper);
            //GameService
            IGameService gameService = new GameService();
            //LeetcodeProblemsService
            ILeetcodeProblemsService leetcodeProblemsService = new LeetcodeProblemsService();
            //MenuService
            MenuService menuService = new MenuService(userService, gameService, leetcodeProblemsService);
            //-------------------------------------------
            

            await menuService.MenuAsync().ConfigureAwait(true);


            //-------TESTING-----
            //wordleService.PlayWordle();  
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
