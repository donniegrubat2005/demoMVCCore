using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace demoMVCCore.Models.Data
{
    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions options) : base(options) { }
                
        public DbSet<Employee> Employees { get; set; }

        }

    }

