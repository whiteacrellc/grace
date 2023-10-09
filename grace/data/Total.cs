using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grace.data
{
    public class Total
    {
        [Key]
        public int ID { get; set; }
        public DateTime date_field { get; set; }
        public int total { get; set; }

        // Foreign key property
        public int GraceID { get; set; }
        // Navigation property
        [ForeignKey("GraceID")]
        public Grace Grace { get; set; }

    }
}
