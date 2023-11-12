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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace grace.utils
{
    internal class PasswordChecker
    {
        public static bool IsPasswordValid(string password)
        {
            // Check length
            if (password.Length < 6)
            {
                return false;
            }

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            // Check for at least one digit
            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            // Check for at least one special character (non-alphanumeric)
            if (!Regex.IsMatch(password, @"[^\w\d]"))
            {
                return false;
            }

            // Password meets all criteria
            return true;
        }
    }
}
