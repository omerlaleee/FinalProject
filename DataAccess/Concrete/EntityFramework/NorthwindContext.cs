using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;    // DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : It connects database tables and project classes
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection Timeout was set to 9999999.
            // Because i got an error like : Microsoft.Data.SqlClient.SqlException: 'Execution Timeout Expired. The timeout period elapsed prior to completion of the operation or the server is not responding.'
            // It was 30 as default.
            string connectionString = @"Data Source=DESKTOP-L9ESE9R\OMER;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=9999999;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            // string connectionString2 = @"Data Source=OMER;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
