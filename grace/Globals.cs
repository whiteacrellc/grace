/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2023
 */
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
