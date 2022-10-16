using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using New.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.Utility
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count()>0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (_db.Roles.Any(r => r.Name == SD.SuperAdmin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.SuperAdmin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.User)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.AdminBKPSDM)).GetAwaiter().GetResult();


            _userManager.CreateAsync(new ApplicationUser
            {
                NIP = "198309112010011008",
                UnitKerja = 0,
                UserName = "Abdul",                
                Email = "admin@gmail.com"
                //Name = "Bhrugen Patel",
                //EmailConfirmed = true,
                //PhoneNumber = "1112223333"
            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.UserName == "Abdul");

            await _userManager.AddToRoleAsync(user, SD.SuperAdmin);

        }

    }
}
