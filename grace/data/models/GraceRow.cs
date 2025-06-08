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

namespace grace.data.models
{
    public partial class GraceRow
    {
        public int ID { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string? Availability { get; set; }
        public string? BarCode { get; set; }
        public string? Col1 { get; set; }
        public string? Col2 { get; set; }
        public string? Col3 { get; set; }
        public string? Col4 { get; set; }
        public string? Col5 { get; set; }
        public string? Col6 { get; set; }
        public int Total { get; set; }
        public int PrevTotal { get; set; }
        public string Note { get; set; }
        public DateTime LastUpdated { get; set; }
        public int GraceId { get; set; }
        public Grace Grace { get; set; }
    }
}
