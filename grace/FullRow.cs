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

namespace grace
{
    public class FullRow
    {
        public FullRow()
        {
            sku = string.Empty;
            brand = string.Empty;
            description = string.Empty;
            total = 0;
            barcode = 0;
            availabilty = string.Empty;
            previousTotal = 0;
            col1 = string.Empty;
            col2 = string.Empty;
            col3 = string.Empty;
            col4 = string.Empty;
            col5 = string.Empty;
            col6 = string.Empty;
            id = 0;
        }

        public string sku { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string availabilty { get; set; }
        public int previousTotal { get; set; }
        public int total { get; set; }
        public long barcode { get; set; }
        public long id { get; set; }
        public string col1 { get; set; }
        public string col2 { get; set; }
        public string col3 { get; set; }
        public string col4 { get; set; }
        public string col5 { get; set; }
        public string col6 { get; set; }
    }
}
