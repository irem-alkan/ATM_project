using Microsoft.EntityFrameworkCore;

namespace ATMWithdrawalApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DebtPayments> DebtPayments { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CustomerRelation> CustomerRelations { get; set; }
        public DbSet<CustomerJob> CustomerJobs { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SIREMALKAN\\SQLEXPRESS;Database=ATM;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
       */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DebtPayments>()
                .Property(d => d.Amount)
                .HasColumnType("decimal(18,2)");

            // Diğer varlık konfigürasyonları buraya eklenebilir

            base.OnModelCreating(modelBuilder);
        }
        // Diğer yapılandırmalar ve metotlar
    }
}
