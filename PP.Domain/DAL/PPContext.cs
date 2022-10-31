using Microsoft.EntityFrameworkCore;
using PP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Domain.DAL
{
    public class PPContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeOrder> EmployeeOrders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-T6L0BBU;Database=PassportPointDb;Trusted_Connection=True;");
        }
    }
}
