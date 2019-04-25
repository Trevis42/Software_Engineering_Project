namespace Contact_Billing_XamarinService.DataObjects
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BillingOBJs : DbContext
    {
        public BillingOBJs()
            : base("name=BillingOBJs")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Call> Calls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.Calls)
                .WithRequired(e => e.Contact)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Billed_Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Calls)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Call>()
                .Property(e => e.Start_Time)
                .IsFixedLength();

            modelBuilder.Entity<Call>()
                .Property(e => e.Amt_Billed)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Call>()
                .Property(e => e.Note)
                .IsUnicode(false);
        }
    }
}
