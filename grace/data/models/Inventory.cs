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
 * Year: 2024
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace.data.models
{
    public class Inventory
    {
        public int ID { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public int PreviousAmount { get; set; } = 0;
        public int Delta { get; set; } = 0;
        public int CurrentTotal { get; set; } = 0;
        public int UserId { get; set; }
        public User User { get; set; }
        public int GraceId { get; set; }
        public Grace Grace { get; set; }
       
    }
}
