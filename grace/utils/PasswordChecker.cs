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
using grace.data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if (password.Length < 4)
            {
                return false;
            }

            /*
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
       */

            // Password meets all criteria
            return true;
        }


        public static bool CheckPassword(string username, string password)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Retrieve the user from the database
                User? user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return false;
                }

                return user.Password == password;
            }

        }

        public static bool IsUserAdmin(string username)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Retrieve the user from the database
                User? user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return false;
                }

                return user.Admin;
            }

        }

        public static bool ResetPassword(string username)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Retrieve the user from the database
                User? user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return false;
                }

                return user.ResetPassword;
            }
        }

        public static bool SetResetFlag(string username)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Retrieve the user from the database
                User? user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return false;
                }

                user.ResetPassword = true;
                dbContext.SaveChanges();
                return true;
            }

        }

        public static int ResetIndex(string username)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Retrieve the user from the database
                User? user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return -1;
                }

                return user.ResetAnswerIndex;
            }

        }

        public static bool UpdateResetAnswer(string username, int index, string answer)
        {
            using (var dbContext = new GraceDbContext())
            {
                // Retrieve the user from the database
                User? user = dbContext.Users
                    .FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    user.ResetAnswer = answer;
                    user.ResetAnswerIndex = index;
                    dbContext.SaveChanges();
                    return true;
                }
            }

        }
    }
}
