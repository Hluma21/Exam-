using CityPointHireExam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CityPointHireExam.Data
{
    public class SeedData
    {
        public static async Task SeedRoomAsync(ApplicationDbContext context)
        {
            if (!await context.Room.AnyAsync())
            {
                var room = new List<Room>
            {
                new Room
                {
                    RoomName = "Room 1",
                    Description = "Sports Hall",
                    HourlyRate = 15,
                    IsAvailable = true

                },
                new Room
                {
                    RoomName = "Room 2",
                    Description = "6th Floor Sandwell college",
                    HourlyRate = 10,
                    IsAvailable = true
                },
                new Room
                {
                    RoomName = "Room 3",
                    Description = "5th Floor Sandwell college",
                    HourlyRate = 67,
                    IsAvailable = false
                }
            };
                await context.Room.AddRangeAsync(room);
                await context.SaveChangesAsync();
            }
        }


        public static async Task SeedBookngsAsync(ApplicationDbContext context)
        {
            if (!await context.Booking.AnyAsync())
            {
                var Room1 = await context.Room.SingleOrDefaultAsync(x => x.RoomName == "Room1");

                if (Room1 == null)
                    return;

                var booking = new Booking
                {
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(6),
                    RoomId = Room1.RoomId
                };
                await context.Booking.AddAsync(booking);
                await context.SaveChangesAsync();
            }
        }


        public static async Task SeedRoles(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Create Roles if they don't exits
            string[] roleNames = { "Staff", "Customer" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
            
            var staffUser = await userManager.FindByEmailAsync("staff@example.com");
            if (staffUser == null)
            {
                staffUser = new IdentityUser { UserName = "staff@example.com", Email = "staff@example.com", PasswordHash = "staffPassword123!" };
                await userManager.CreateAsync(staffUser, "staff@123");
            }

            if(!await userManager.IsInRoleAsync(staffUser, "Staff"))
            {
                await userManager.AddToRoleAsync(staffUser, "Staff");
            }
        }
    }
}


