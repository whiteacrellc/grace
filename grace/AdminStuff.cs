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
using System.Runtime.CompilerServices;
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
                    string[] defaultUsers = { "patster", "susan",
                    "christa", "mandy", "whitney" };

                    foreach (var user in defaultUsers)
                    {
                        if (user != null)
                        {
                            User u = new User();
                            u.Username = user;
                            u.Password = "changeme";
                            if (user.Equals("patster", StringComparison.Ordinal) || user.Equals("susan", StringComparison.Ordinal))
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

        public static List<string> getUserNames()
        {
            List<string> usernames = new();
            using (GraceDbContext graceDb = new())
            {
                try
                {
                    List<User> users = [.. graceDb.Users.Where(e => !e.Deleted)];
                    foreach (User user in users)
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

        public static void DeleteUser(string username)
        {
            using GraceDbContext graceDb = new();
            try
            {
                User u = graceDb.Users.FirstOrDefault(e => e.Username == username);
                if (u != null)
                {
                    u.Deleted = true;
                    graceDb.Users.Update(u);
                    graceDb.SaveChanges();
                    logger.Info("deleted user " + username);
                }
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
            }
        }

        public static bool CreateUser(string username, string password,
            bool forcePasswordReset, bool isAdmin)
        {
            using GraceDbContext graceDb = new();
            try
            {
                User u = graceDb.Users.FirstOrDefault(e => e.Username == username);
                if (u != null)
                {
                    if (u.Deleted)
                    {
                        DialogResult response = MessageBox.Show("Username " + username +
                            " already exists but was deleted, do you want to "
                            + "restore the user?", "User Dialog",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (response == DialogResult.Yes)
                        {
                            u.Deleted = false;
                            graceDb.Users.Update(u);
                            graceDb.SaveChanges();
                            logger.Info("undeleted user " + username);
                            return true;
                        }
                    }
                    else
                    {
                        DialogResult response = MessageBox.Show("Username " + username +
                           " already exists.", "User Dialog",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                u = new User
                {
                    Username = username,
                    Password = password,
                    ResetPassword = forcePasswordReset,
                    Admin = isAdmin
                };
                graceDb.Users.Add(u);
                graceDb.SaveChanges();
                logger.Info("created user " + username);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
            }
            return false;
        }
    }
}
