using System.ComponentModel.DataAnnotations;

namespace grace.data
{
    public class GraceRow
    {
        [Key]
        public int ID { get; set; }
        [Required]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Sku { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string? Availability { get; set; }
        public string? Barcode { get; set; }
        public string? Col1 { get; set; }
        public string? Col2 { get; set; }
        public string? Col3 { get; set;
        public string? Col4 { get; set;}
        public string? Col5 { get; set;}
        public string? Col6 { get; set;}
        public int PreviousTotal { get; set; } = 0;
        public int Total { get; set;} = 0;
    }
}
