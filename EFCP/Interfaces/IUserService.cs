using EFCP.models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.Interfaces
{
    public interface IUserService
    {
        public Task AddUserAsync(UserDto userDto);
        public Task UpdateUserAsync(UserDto userDto, int id);
        public Task DeleteUserAsync(int id);
        public Task<UserDto> GetUserAsync(int id);
        public Task<List<UserDto>> GetUsersAsync();

        public Task ExportUsersTXT(string path);
        public Task ExportUsersCSV(string path);
        public Task ExportUsersXML(string path);
        public Task ExportUserTXT(string path, int id);
        public Task ExportUserCSV(string path, int id);
        public Task ExportUserXML(string path, int id);

        public Task UserManagementMenuAsync();
        public Task ExportMenuAsync();
        public Task CRUDMenuAsync();

    }
}
