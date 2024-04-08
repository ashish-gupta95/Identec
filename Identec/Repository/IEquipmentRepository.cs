using Identec.Model;

namespace Identec.Repository
{
    public interface IEquipmentRepository
    {
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task SaveAsync();
    }
}
