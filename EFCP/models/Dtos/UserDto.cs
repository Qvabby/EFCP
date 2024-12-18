using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.models.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public uint Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Lastname: {Lastname}, Email: {Email}, Age: {Age}";
        }
    }
}
