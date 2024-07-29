using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using salesApp.Models;

namespace salesApp.Data
{
    public class salesAppContext : DbContext
    {
        public salesAppContext (DbContextOptions<salesAppContext> options)
            : base(options)
        {
        }

        public DbSet<salesApp.Models.Department> Department { get; set; } = default!;
    }
}
