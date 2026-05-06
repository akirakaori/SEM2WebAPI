using SEM2WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SEM2WebAPI.Data
{
    public class AppDbContext : IdentityDbContext<User> //identitydbcontext vitra sabai db context cha so hamle appdbcontext.cs vitra identitydbcontext inherit gareko
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // table name change for identity tables, relationaship configuration for many to many tables etc.
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");

            SeedRoles(builder); //seed initial roles into the db

        }

        public void SeedRoles(ModelBuilder builder)
        {
            List<IdentityRole> identityRoles =
                [
                    new IdentityRole{
                        Id = "410ffe09-548f-4c00-830b-f234a2b9e0e4", //guid value dina parcha because guid work garden in 10 so value rakhna parcha from guid value generator in browser
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = "a4cbcdc3-2cb6-4569-b1cf-d301a63cd490" //Guide.NewGuid().ToString()
                    },

                     new IdentityRole{
                        Id = "3f3319aa-44f1-45a2-9c45-065864e1dd75", //guid value dina parcha because guid work garden in 10 so value rakhna parcha from guid value generator in browser
                        Name = "Student",
                        NormalizedName = "Student",
                        ConcurrencyStamp = "aca4779f-9168-46d3-bfd6-205cd0162ed1" //Guide.NewGuid().ToString()
                    },

                    new IdentityRole{
                        Id = "1bd965c0-4f07-46de-b4ab-9a672045834a", //guid value dina parcha because guid work garden in 10 so value rakhna parcha from guid value generator in browser
                        Name = "Instructor",
                        NormalizedName = "Instructor",
                        ConcurrencyStamp = "36ed5fbc-7faa-4de7-b639-8bb4021fb855" //Guide.NewGuid().ToString()
                    }

                ];
            builder.Entity<IdentityRole>().HasData(identityRoles);
          

        }

    }
}
