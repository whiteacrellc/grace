using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    public class Globals
    {
        public Globals() {
            NumberReportColumns = 12;
            NumberInputColumns = 13;
            HeaderHeight = Properties.Settings.Default.headerheight;

        }
        public int NumberReportColumns { get; set; }
        public int NumberInputColumns { get; set; }
        public int HeaderHeight { get; set;}
    }
}
