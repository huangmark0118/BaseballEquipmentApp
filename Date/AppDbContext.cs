using Microsoft.EntityFrameworkCore;
using BaseballEquipmentApp.Models;

namespace BaseballEquipmentApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BaseballEquipment> BaseballEquipments { get; set; }
    }
}