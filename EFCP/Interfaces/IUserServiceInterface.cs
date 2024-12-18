using EFCP.models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.Interfaces
{
    public interface IUserServiceInterface
    {
        public void AddUser(UserDto userDto);
        public void UpdateUser(UserDto userDto, int id);
        public void DeleteUser(int id);
        public Task<UserDto> GetUser(int id);
        public Task<List<UserDto>> GetUsers();

    }
}
