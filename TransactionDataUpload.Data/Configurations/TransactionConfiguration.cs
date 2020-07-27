using System.Data.Entity.ModelConfiguration;
using TransactionDataUpload.Data.Entities;

namespace TransactionDataUpload.Data.Configurations
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public void Configure()
        {
            Property(p => p.FileName).IsRequired();
            HasMany(e => e.Data);
        }
    }
}
