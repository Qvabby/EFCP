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
        ConsoleMessagesWriter _writer = new ConsoleMessagesWriter();
        public UserService(EFCPDbContext dbcontext, IMapper mapper) { _dbContext = dbcontext; _mapper = mapper; }
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
    }
}
