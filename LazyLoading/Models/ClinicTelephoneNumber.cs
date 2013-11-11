using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Models
{
    [Table("ClinicTelephoneNumbers")]
    public class ClinicTelephoneNumber
    {
        [Key, Column(Order = 0), ForeignKey("Clinic"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClinicId { get; set; }

        [Key, Column(Order = 1), ForeignKey("TelephoneNumber"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TelephoneNumberId { get; set; }

        public virtual Clinic Clinic { get; set; }

        public virtual TelephoneNumber TelephoneNumber { get; set; }
    }
}