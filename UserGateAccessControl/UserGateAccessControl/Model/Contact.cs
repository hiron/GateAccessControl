using System;
using System.Collections.Generic;

namespace UserGateAccessControl.Model
{
    public class Contact
    {
        public int ContactId { get; set; }

        public ContactType Type { get; set; }

        public int LandId { get; set; }

        public string Name { get; set; }

        public bool Signature { get; set; }

        public DateTime ModificationDate { get; set; }

        public bool EnableExtend { get; set; }

        public string Comments { get; set; }

        public virtual ICollection<PhoneRecord> Phones { get; set; }
    }
}
