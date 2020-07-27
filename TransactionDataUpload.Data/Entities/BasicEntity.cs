using System.ComponentModel.DataAnnotations;

namespace TransactionDataUpload.Data.Entities
{
    public abstract class BasicEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
