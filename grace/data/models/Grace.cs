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


namespace grace.data.models
{
    public partial class Grace
    {
        public int ID { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string? Availability { get; set; }
        public string? Barcode { get; set; }

    }
}
