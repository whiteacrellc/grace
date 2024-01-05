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
    public partial class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ResetAnswer { get; set; } = string.Empty;
        public int ResetAnswerIndex { get; set; }
        public bool Admin { get; set; } = false;
        public bool ResetPassword { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
