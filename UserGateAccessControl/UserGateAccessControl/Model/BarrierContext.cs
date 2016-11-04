using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SQLite.CodeFirst;

namespace UserGateAccessControl.Model
{
    public class BarrierContext : DbContext
    {
        public BarrierContext()
            : base("name=Model")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Contact>().ToTable("Contact").HasKey(c => c.ContactId);
            modelBuilder.Entity<Contact>().Property(c => c.Type);
            modelBuilder.Entity<Contact>().Property(c => c.LandId);
            modelBuilder.Entity<Contact>().Property(c => c.Name);
            modelBuilder.Entity<Contact>().Property(c => c.Signature);
            modelBuilder.Entity<Contact>().Property(c => c.ModificationDate);
            modelBuilder.Entity<Contact>().Property(c => c.EnableExtend);
            modelBuilder.Entity<Contact>().Property(c => c.Comments).IsVariableLength();

            modelBuilder.Entity<PhoneRecord>().ToTable("Phone").HasKey(c => c.RecordId);
            modelBuilder.Entity<PhoneRecord>().Property(c => c.Phone);
            modelBuilder.Entity<PhoneRecord>().Property(c => c.IsConfirm);
            modelBuilder.Entity<PhoneRecord>().HasRequired(p => p.Contact)
                .WithMany(c => c.Phones);

            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<BarrierContext>(modelBuilder);

            Database.SetInitializer(sqliteConnectionInitializer);
            base.OnModelCreating(modelBuilder);
        }
    }
}
