using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public uint Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Lastname: {Lastname}, Email: {Email}, Age: {Age}";
        }

    }
}
