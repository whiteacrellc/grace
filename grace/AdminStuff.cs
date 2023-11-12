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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    internal class AdminStuff
    {
        private static string[] resetPasswordQuestions = {
            "What is your mother's maiden name?",
            "In which city were you born?",
            "What is the name of your first pet?",
            "What is your favorite movie?",
            "What is your favorite book?",
            "What is the name of your elementary school?",
            "What is the model of your first car?",
            "What is your favorite food?",
            "What is the name of your favorite teacher?",
            "What is the make of your first bike?",
            "What is your favorite swear word?",
        };

        private GraceDbContext graceDb;

        public AdminStuff()
        {

            graceDb = new GraceDbContext();

        }

        public void InitUserDB()
        {
            graceDb.Database.EnsureCreated();
            List<User> users = graceDb.Users.ToList();

            if (users.Count == 0)
            {

                var prefusers = Properties.Settings.Default.users;
                foreach (var user in prefusers)
                {
                    if (user != null)
                    {
                        User u = new User();
                        u.Username = user;
                        u.Password = "changeme";
                        if (user.Equals("patti") || user.Equals("susan"))
                        {
                            u.Admin = true;
                        }
                        u.ResetPassword = true;
                        users.Add(u);
                    }
                }
                graceDb.SaveChanges();
            }
        }

        public List<string>getUserNames()
        {
            List<string> usernames = new List<string>();
            List<User> users = graceDb.Users.ToList();
            foreach (var user in users)
            {
                usernames.Add(user.Username);
            }
            return usernames;
        }
    }
}
