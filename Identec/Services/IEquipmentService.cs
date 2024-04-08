using Identec.Model;

namespace Identec.Services
{
    public interface IEquipmentService
    {
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task UpdateEquipmentAsync(Equipment equipment);

    }
}