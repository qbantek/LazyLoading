using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Models
{
    [Table("TelephoneNumbers")]
    public class TelephoneNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TelephoneNumberId { get; set; }

        public PhoneType PhoneType { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public bool Deleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOnUtc { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOnUtc { get; set; }
    }
}