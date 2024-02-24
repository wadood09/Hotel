using EFPract.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Infrastructure.Context
{
    public class StudContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL("Server=localhost;user=root;database=PractDb;password=Pa$$word");
    }
}
