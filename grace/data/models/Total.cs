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
    public partial class Total
    {
        public int ID { get; set; }
        public DateTime date_field { get; set; }
        public int total { get; set; }
        public int GraceId { get; set; }
        public Grace Grace { get; set; }
    }
}
