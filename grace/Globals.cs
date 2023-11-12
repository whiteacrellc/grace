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
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace
{
    public class Globals
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static Globals instance;

        private int rowHeight = 35;
        private int rowsPerPage = 40;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private Globals()
        {
            rowHeight = Properties.Settings.Default.rowheight;
            rowsPerPage = Properties.Settings.Default.rowsperpage;

            initializeUsers();
        }
        public static Globals GetInstance()
        {
            // If the instance doesn't exist, create it
            if (instance == null)
            {
                instance = new Globals();
            }
            return instance;
        }


        public int RowHeight
        {
            get { return rowHeight; }
            set
            {
                rowHeight = value;
                //   Properties.Settings.Default.rowheight = value;
                //  Properties.Settings.Default.Save();
            }
        }

        public int RowsPerPage
        {
            get { return rowsPerPage; }
            set
            {
                rowHeight = value;
                //Properties.Settings.Default.rowsperpage = value;
                //Properties.Settings.Default.Save();
            }
        }

        private string[] defaultUsers = { "patti", "susan", "morgan",
            "christa", "mandy", "whitney" };

        private void initializeUsers()
        {
            bool initPref = false;
            try
            {
                var users = Properties.Settings.Default.users;
                if (users == null || users.Count == 0)
                {
                    initPref = true;
                }
            }
            catch (Exception ex)
            {
                initPref = true;
                logger.Warn(ex);

            }
            if (initPref)
            {
                System.Collections.Specialized.StringCollection myCollection
                    = new System.Collections.Specialized.StringCollection();

                foreach (var user in defaultUsers)
                {
                    myCollection.Add(user);
                }
                Properties.Settings.Default.users = myCollection;
                Properties.Settings.Default.Save();

            }
            AdminStuff adminStuff = new AdminStuff();
            adminStuff.InitUserDB();
        }







        public DateTime currentHeaderDate { get; set; } = DateTime.Now;
        public DateTime previousHeaderDate { get; set; } = DateTime.Now.AddDays(-14);

        public string ConnectionString { get; set; }

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

