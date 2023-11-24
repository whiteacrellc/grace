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


        private GraceDbContext graceDb;

        public AdminStuff()
        {

            graceDb = new GraceDbContext();

        }

        public void InitUserDB()
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
                        if (user.Equals("patti") || user.Equals("susan"))
                        {
                            u.Admin = true;
                        }
                        u.ResetPassword = true;
                        graceDb.Users.Add(u);
                    }
                }
                graceDb.SaveChanges();
            }
        }

        public List<string>getUserNames()
        {
            List<string> usernames = new List<string>();
            try
            {
                List<User> users = graceDb.Users.ToList();
                foreach (var user in users)
                {
                    usernames.Add(user.Username);
                }
            } catch (Exception ex) 
            {
                logger.Warn(ex);
            }
            return usernames;
        }
    }
}
