using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace.data.models
{
    internal class ArrangementTotal
    {
        public int ID { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public int CurrentTotal { get; set; }
        public int ArrangementId { get; set; }
        public Arrangement Arrangement { get; set; }
        public String User { get; set; }
    }
}
