using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesStructureChecking.Domain.Base
{
    public abstract class EntityBase
    {
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; protected set; }

        [Required]
        public DateTime CreatedAt { get; protected set; }

        [Required]
        public DateTime ModifiedAt { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public EntityBase()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
