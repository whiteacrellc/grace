using grace.data.models;
using NLog;

namespace grace.data
{
    public class Preferences
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Define an enum named DaysOfWeek
        public enum Preference
        {
            RowHeight,
            RowsPerPage,
            Tuesday,
            HeaderHeight,
            BarCodeAutoOpen
        }

        public Preferences()
        {
        }

        public static string? GetStringValue(Preference pref)
        {
            Prefs? preference = null;
            var name = pref.ToString();

            using (var _context = new GraceDbContext())
            {
                preference = _context.PrefsDb.FirstOrDefault(p => p.Name == name);
            }
            return preference?.Value; // If preference is null, return null, otherwise return the Value
        }

        public static int GetIntValue(Preference pref)
        {
            int ret = 0;
            var name = pref.ToString();
            using (var _context = new GraceDbContext())
            {
                var preference = _context.PrefsDb.FirstOrDefault(p => p.Name == name);

                if (preference != null)
                {
                    try
                    {
                        ret = Int32.Parse(preference.Value);
                    }
                    catch (FormatException fe)
                    {
                        logger.Error(fe);
                    }
                }
            }
            return ret;
        }

        public static bool GetBooleanValue(Preference pref)
        {
            bool ret = false;
            var name = pref.ToString();
            using (var _context = new GraceDbContext())
            {
                var preference = _context.PrefsDb.FirstOrDefault(p => p.Name == name);

                if (preference != null)
                {
                    try
                    {
                        ret = Boolean.Parse(preference.Value);
                    }
                    catch (FormatException fe)
                    {
                        logger.Error(fe);
                    }
                }
            }
            return ret;
        }

        public static void AddOrUpdateIntPreference(Preference pref, int value)
        {
            string string_val = value.ToString();
            var name = pref.ToString();
            AddOrUpdateStringPreference(name, string_val);
        }

        public static void AddOrUpdateBooleanPreference(Preference pref, bool value)
        {
            string val = (value) ? "true" : "false";
            var name = pref.ToString();
            AddOrUpdateStringPreference(name, val);
        }

        public static void AddOrUpdateStringPreference(Preference pref, string value)
        {
            var name = pref.ToString();
            AddOrUpdateStringPreference(name, value);
        }

        private static void AddOrUpdateStringPreference(string name, string value)
        {
            using var _context = new GraceDbContext();
            var existingPreference = _context.PrefsDb.FirstOrDefault(p => p.Name == name);

            if (existingPreference != null)
            {
                // Update the existing preference
                existingPreference.Value = value;
            }
            else
            {
                // Add a new preference if it doesn't exist
                var newPreference = new Prefs { Name = name, Value = value };
                _context.PrefsDb.Add(newPreference);
            }

            _context.SaveChanges(); // Save changes to the database
        }
    }
}
