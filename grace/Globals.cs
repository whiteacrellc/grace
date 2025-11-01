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

namespace grace
{
    public class Globals
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static Globals instance;

        public string CurrentUser { get; set; }
        public bool CollectionDirty { get; set; }

        private Globals()
        {
            CollectionDirty = false;
        }
        public static Globals GetInstance()
        {
            // If the instance doesn't exist, create it
            instance ??= new Globals();
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
            get => Preferences.GetIntValue(Preferences.Preference.HeaderHeight); set => Preferences.AddOrUpdateIntPreference(Preferences.Preference.HeaderHeight, value);
        }

        public bool BarCodeAutoOpen
        {
            get => Preferences.GetBooleanValue(Preferences.Preference.BarCodeAutoOpen); set => Preferences.AddOrUpdateBooleanPreference(Preferences.Preference.BarCodeAutoOpen, value);
        }

        public DateTime CurrentHeaderDate { get; set; } = DateTime.Now;
        public DateTime PreviousHeaderDate { get; set; } = DateTime.Now.AddDays(-14);

    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

