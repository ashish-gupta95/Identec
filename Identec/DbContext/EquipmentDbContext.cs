using Identec.Model;
using Microsoft.EntityFrameworkCore;

namespace Identec.Data.EquipmentDbContext

{
    public class EquipmentDbContext : DbContext
    {
        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }

    }
}
