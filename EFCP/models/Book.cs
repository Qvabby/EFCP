using EFCP.Data.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.models
{
    //Or We can Configure it like this.
    [EntityTypeConfiguration(typeof(BookEntityTypeConfiguration))]
    public class Book
    {
        public int id { get; set; }
        public string title { get;set; }
        public string description { get;set; }
    }
}
