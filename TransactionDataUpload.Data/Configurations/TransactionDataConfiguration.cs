using System.Data.Entity.ModelConfiguration;
using TransactionDataUpload.Data.Entities;

namespace TransactionDataUpload.Data.Configurations
{
    public class TransactionDataConfiguration : EntityTypeConfiguration<TransactionData>
    {
        public void Configure()
        {
            Property(p => p.Identificator).IsRequired().HasMaxLength(50);
            Property(p => p.TransactionDate).IsRequired();
            Property(p => p.Amount).IsRequired();
            Property(p => p.CurrencyCode).IsRequired();
            Property(p => p.Status).IsRequired();
        }
    }
}
