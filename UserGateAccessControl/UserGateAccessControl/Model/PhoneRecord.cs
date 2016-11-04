
namespace UserGateAccessControl.Model
{
    public class PhoneRecord
    {
        public int RecordId { get; set; }

        public int ContactId { get; set; }

        public string Phone { get; set; }

        public bool IsConfirm { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
