namespace Identec.Model
{
    public class BaseEquipment
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class Equipment : BaseEquipment
    {
        public string Name { get; set; }

    }

    public class EquipmentRequestModel : BaseEquipment
    {
    }
}
