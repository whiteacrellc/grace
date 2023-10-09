using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    internal class GraceRow
    {
        public long Id { get; set; } = 0;
        public string Sku { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string? Availability { get; set; } = null; 
        public string? BarCode { get; set; } = null;
        public string? Col1 { get; set; } = null;
        public string? Col2 { get; set; } = null;
        public string? Col3 { get; set; } = null;
        public string? Col4 { get; set; } = null;
        public string? Col5 { get; set; } = null;
        public string? Col6 { get; set; } = null;
        public int PreviousTotal { get; set; } = 0;
        public int Total { get; set; } = 0;

        public GraceRow() { }
    }
}
