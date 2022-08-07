using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Models;
using PersonalWebsite.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<EducationModel> Educations { get; set; }
        public DbSet<ExperienceModel> Experiences { get; set; }
        public DbSet<MyInfoModel> MyInfos { get; set; }
        public DbSet<ServicesModel> Services { get; set; }
        public DbSet<SkillsModel> Skills { get; set; }
    }
}
