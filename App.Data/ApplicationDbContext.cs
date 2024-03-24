using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            //GUID
            string Admin_Role_Id = "9a00de05-ab2c-4692-82b2-d33f0f50eb7e";
            string PublicUser_Role_Id = "6472ca7d-4acb-4550-9b9f-2d03321ad5e6";
            string Admin_User_Id = "f1446937-109c-4e1a-97ce-0560442484f5";

            //Add Roles
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Admin_Role_Id,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Admin_Role_Id

            });
            Builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = PublicUser_Role_Id,
                Name = "publicUser",
                NormalizedName = "PUBLICUSER",
                ConcurrencyStamp = PublicUser_Role_Id
            });

            //create object of Application USer
            var adminUser = new ApplicationUser
            {
                Id = Admin_User_Id,
                FullName = "Mahmoud Sameer",
                Email = "mahmoud@admin.com",
                NormalizedEmail = "MAHMOUD@ADMIN.COM",
                UserName = "Mahmoud_Sameer",
                UserType =0,
                Gender = "male",
            };

            //Password Hasher
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
            Builder.Entity<ApplicationUser>().HasData(adminUser);

            //Add Role To AdminUser
            Builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Admin_Role_Id,
                    UserId = Admin_User_Id
                }
                );
            base.OnModelCreating(Builder);

        }
        public DbSet<User> Users { get; set; }

    }
}
