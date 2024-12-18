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

namespace EFCP.Services
{
    public class UserService : IUserServiceInterface
    {
        EFCPDbContext _dbContext;
        IMapper _mapper;
        public UserService(EFCPDbContext dbcontext, IMapper mapper) { _dbContext = dbcontext; _mapper = mapper; }
        public void AddUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _dbContext.Add(user);
                _dbContext.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{user.ToString()}");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = _dbContext.Users
                .FirstOrDefault(x => x.Id == id);

                _dbContext.Users.Remove(user);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succesfully Removed User.");
                Console.ResetColor();
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public async Task<UserDto> GetUser(int id)
        {
            try
            {
                var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return null;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                var userDtos = _mapper.Map<List<UserDto>>(users);
                return userDtos;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            return null;
        }

        public void UpdateUser(UserDto userDto, int id)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
                user.Name = userDto.Name;
                user.Email = userDto.Email;
                user.Age = userDto.Age;
                user.Lastname = userDto.Lastname;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succesfully Updated User.");
                Console.ResetColor();
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}
