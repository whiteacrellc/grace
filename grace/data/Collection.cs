using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grace.data
{
    public class Collection
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        // Foreign key property
        public int GraceID { get; set; }
        // Navigation property
        [ForeignKey("GraceID")]
        public Grace Grace { get; set; }

    }
}
