using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnguCore.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            AddedDate = DateTime.UtcNow;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
