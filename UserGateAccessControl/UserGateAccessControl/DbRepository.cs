using UserGateAccessControl.Model;

namespace UserGateAccessControl
{
    public class DbRepository
    {
        public void AddContact(Contact contact)
        {
            using (var dbcontext = GetContext())
            {
                dbcontext.Contacts.Add(contact);
                dbcontext.SaveChanges();
            }
        }

        private BarrierContext GetContext()
        {
            return new BarrierContext();
        }

    }
}
