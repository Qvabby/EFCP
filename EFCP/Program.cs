using AutoMapper;
using AutoMapper.Configuration;
using EFCP.Data;
using EFCP.models.Dtos;
using EFCP.models;
using EFCP.Services;
using qvabbytesD1;
using EFCP.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            //DBContext
            await using var db = new EFCPDbContext();

            //Mapping Configuration
            var configExpression = new MapperConfigurationExpression();
            configExpression.CreateMap<User, UserDto>().ReverseMap();
            var log = LoggerFactory.Create(x => x.Services.AddLogging());
            var mappingConfig = new MapperConfiguration(configExpression, log);
            //Mapper
            var mapper = mappingConfig.CreateMapper();
            
            //---------------- Services -----------------
            //var services = new ServiceCollection();    <--- More professional.
            //services.AddDbContext<EFCPDbContext>();

            //UserService
            IUserService userService = new UserService(db, mapper);
            //GameService
            IGameService gameService = new GameService();
            //LeetcodeProblemsService
            ILeetcodeProblemsService leetcodeProblemsService = new LeetcodeProblemsService();
            //MenuService
            var menuService = new MenuService(userService, gameService, leetcodeProblemsService);
            //StartEFCP
            await menuService.MenuAsync();


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
