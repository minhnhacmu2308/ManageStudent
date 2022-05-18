using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ManagementStudent.Models
{
    public class ManageDbContext : DbContext
    {
        public ManageDbContext() : base("QuanLyDBConnectionString")
        {

        }
        public DbSet<Day> days { get; set; }

        public DbSet<Majors> majors { get; set; }

        public DbSet<Schedule> schedules { get; set; }

        public DbSet<Subject> subjects { get; set; }

        public DbSet<Score> scores { get; set; }

        public DbSet<Session> sessions { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<User> users { get; set; }
    }
}