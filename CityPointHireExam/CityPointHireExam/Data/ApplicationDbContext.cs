using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CityPointHireExam.Models;

namespace CityPointHireExam.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CityPointHireExam.Models.Booking> Booking { get; set; } = default!;
        public DbSet<CityPointHireExam.Models.Staff> Staff { get; set; } = default!;
        public DbSet<CityPointHireExam.Models.Room> Room { get; set; } = default!;
    }
}
