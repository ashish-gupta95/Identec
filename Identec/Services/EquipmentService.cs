using Identec.Model;
using Identec.Repository;

namespace Identec.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _equipmentRepository.GetEquipmentByIdAsync(id);
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(equipment.Id);
            if (existingEquipment == null)
            {
                throw new ArgumentException("Equipment not found");
            }

            existingEquipment.Status = equipment.Status;
            await _equipmentRepository.SaveAsync();
        }
    }
}
