using Identec.Data.EquipmentDbContext;
using Identec.Model;
using Microsoft.EntityFrameworkCore;

namespace Identec.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly EquipmentDbContext _context;
        public EquipmentRepository(EquipmentDbContext context)
        {
            _context = context;
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _context.Equipments.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
