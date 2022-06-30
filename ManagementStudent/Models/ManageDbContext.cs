using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

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

        public DbSet<Post> posts { get; set; }

        public DbSet<Feedback> feedbacks { get; set; }

        public DbSet<Credit> credits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}