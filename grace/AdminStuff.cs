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
using grace.data.models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    internal class AdminStuff
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static Logger Logger => logger;

        public static void InitUserDB()
        {
            using (var graceDb = new GraceDbContext())
            {
                bool empty = !graceDb.Users.Any();

                if (empty)
                {
                    string[] defaultUsers = { "patti", "susan", "morgan",
                    "christa", "mandy", "whitney" };

                    foreach (var user in defaultUsers)
                    {
                        if (user != null)
                        {
                            User u = new User();
                            u.Username = user;
                            u.Password = "changeme";
                            if (user.Equals("patti", StringComparison.Ordinal) || user.Equals("susan", StringComparison.Ordinal))
                            {
                                u.Admin = true;
                            }
                            u.ResetPassword = true;
                            graceDb.Users.Add(u);
                            u.Deleted = false;
                        }
                    }
                    graceDb.SaveChanges();
                }
            }
        }

        public static List<string>getUserNames()
        {
            List<string> usernames = new List<string>();
            using (var graceDb = new GraceDbContext())
            {
                try
                {
                    List<User> users = graceDb.Users
                        .Where(e => e.Deleted == false)
                        .ToList();
                    foreach (var user in users)
                    {
                        usernames.Add(user.Username);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex);
                }
            }
            return usernames;
        }
    }
}
