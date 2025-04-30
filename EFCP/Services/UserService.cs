using AutoMapper;
using EFCP.Interfaces;
using EFCP.models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCP.Data;
using EFCP.models;
using qvabbytesD1;
using EFCP.HelperMethods;

namespace EFCP.Services
{
    public class UserService : IUserService
    {
        EFCPDbContext _dbContext;
        IMapper _mapper;
        //Console Visualizers.
        ConsoleMessagesWriter _writer = new ConsoleMessagesWriter();
        ConsoleOutputVisualizer _visualizer;
        //---ctor
        public UserService(EFCPDbContext dbcontext, IMapper mapper) { _dbContext = dbcontext; _mapper = mapper; _visualizer = new ConsoleOutputVisualizer(); }

        //--------------------CRUD OPERATIONS
        public async Task AddUserAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                _writer.WriteSuccessMessage($"{user.ToString()}");
            }
            catch (Exception e)
            {
                _writer.WriteErrorMessage(e.Message);
            }
        }
        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    _writer.WriteErrorMessage("User not found.");
                    return;
                }
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                _writer.WriteSuccessMessage("Succesfully Removed User.");
            }
            catch (Exception e)
            {
                _writer.WriteErrorMessage(e.Message);
            }

        }
        public async Task<UserDto> GetUserAsync(int id)
        {
            try
            {
                var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    _writer.WriteErrorMessage("User not found.");
                    return null;
                }
                var userDto = _mapper.Map<UserDto>(user);
                _writer.WriteSuccessMessage("Succesfully Fetched User.");
                return userDto;
            }
            catch (Exception e)
            {
                _writer.WriteErrorMessage($"{e.Message}");
            }
            return null;
        }
        public async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                if (users == null)
                {
                    _writer.WriteErrorMessage("Users not found.");
                    return null;
                }
                var userDtos = _mapper.Map<List<UserDto>>(users);
                return userDtos;
            }
            catch (Exception e)
            {
                _writer.WriteErrorMessage($"{e.Message}");
            }
            return null;
        }
        public async Task UpdateUserAsync(UserDto userDto, int id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User not found.");
                    Console.ResetColor();
                    return;
                }
                user.Name = userDto.Name;
                user.Email = userDto.Email;
                user.Age = userDto.Age;
                user.Lastname = userDto.Lastname;
                _writer.WriteSuccessMessage("Succesfully Updated User.");
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _writer.WriteErrorMessage(e.Message);
            }
        }

        //---------------------EXPORTING OPERATORS
        public Task ExportUserCSV(string path, int id)
        {
            throw new NotImplementedException();
        }

        public Task ExportUsersCSV(string path)
        {
            throw new NotImplementedException();
        }

        public Task ExportUsersTXT(string path)
        {
            throw new NotImplementedException();
        }

        public Task ExportUsersXML(string path)
        {
            throw new NotImplementedException();
        }

        public Task ExportUserTXT(string path, int id)
        {
            throw new NotImplementedException();
        }

        public Task ExportUserXML(string path, int id)
        {
            throw new NotImplementedException();
        }


        //---------------------MENU
        public async Task UserManagementMenuAsync()
        {
            //Implement Helping Methods.
            MenuHelperMethods menuHelperMethods = new MenuHelperMethods(_visualizer);
            //Print Menu
            _visualizer.Qprint("User Management Menu", "Green");
            var optionsNums = menuHelperMethods.printMenuOptions(new List<string> { "1. CRUD (Add/Read/Update/Delete)", "2. Export(TXT/CSV/XML)", "3. Go Back" });
            _visualizer.BreakLine();
            _visualizer.QprintOnLine("Select an option: ", "White");
            Console.ForegroundColor = ConsoleColor.Blue;
            var input = Console.ReadLine();
            Console.ResetColor();
            //Check if input is valid.
            if (!menuHelperMethods.isValidInput(input, optionsNums))
            {
                _writer.WriteErrorMessage("Invalid input. Please try again.");
                await UserManagementMenuAsync();
            }
            //Calling the corresponding service based on the input.
            switch (input)
            {
                //CRUD
                case "1":

                    break;
                //Export
                case "2":

                    break;
                //Go Back
                case "3":
                    break;

                default:
                    break;
            }


        }
        public Task ExportMenuAsync()
        {
            throw new NotImplementedException();
        }
    }
}
