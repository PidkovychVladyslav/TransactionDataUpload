using System.Data.Entity;
using TransactionDataUpload.Data.Entities;

namespace TransactionDataUpload.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionData> TransactionDatas { get; set; }

        public DataContext()
            : base("TDUConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
