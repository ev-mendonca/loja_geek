using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public int ID { get; set; }
    }

}
