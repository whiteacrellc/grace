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
    public class Globals
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static Globals instance;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private Preferences prefs;

        public string CurrentUser { get; set; }
        public bool CollectionDirty { get; set; }

        private Globals()
        {
            prefs = new Preferences();
            CollectionDirty = false;
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
            get => Preferences.GetIntValue(Preferences.Preference.RowHeight);
            set => Preferences.AddOrUpdateIntPreference(Preferences.Preference.RowHeight, value);
        }

        public int RowsPerPage
        {
            get => Preferences.GetIntValue(Preferences.Preference.RowsPerPage);
            set => Preferences.AddOrUpdateIntPreference(Preferences.Preference.RowsPerPage, value);
        }

        public int HeaderHeight
        {
            get
            {
                return Preferences.GetIntValue(Preferences.Preference.HeaderHeight);
            }
            set
            {
                Preferences.AddOrUpdateIntPreference(Preferences.Preference.HeaderHeight, value);
            }
        }

        public bool BarCodeAutoOpen
        {
            get
            {
                return Preferences.GetBooleanValue(Preferences.Preference.BarCodeAutoOpen);
            }
            set
            {
                Preferences.AddOrUpdateBooleanPreference(Preferences.Preference.BarCodeAutoOpen, value);
            }
        }

        public DateTime CurrentHeaderDate { get; set; } = DateTime.Now;
        public DateTime PreviousHeaderDate { get; set; } = DateTime.Now.AddDays(-14);

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

