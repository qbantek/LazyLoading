using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Models
{
    [Table("Clinics")]
    public class Clinic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClinicId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

        public virtual ICollection<ClinicTelephoneNumber> TelephoneNumbers { get; set; }
    }
}