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
using System.ComponentModel.DataAnnotations;


namespace grace.data.models
{
    public partial class Grace
    {
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Sku must be between 3 and 50 characters.")]
        public string Sku { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 characters.")]
        public string Description { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand must be between 3 and 50 characters.")]
        public string Brand { get; set; }
        public string Availability { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string Note {  get; set; } = string.Empty;
        public bool Deleted { get; set; } = false;

    }
}
