using NLog;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grace.data
{
    public class Preferences
    {
        private readonly GraceDbContext _context;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Preferences()
        {
            _context = new GraceDbContext();
        }

        public string? GetStringValue(string name)
        {
            var preference = _context.PrefsDb.FirstOrDefault(p => p.Name == name);

            return preference?.Value; // If preference is null, return null, otherwise return the Value
        }

        public int GetIntValue(string name)
        {
            var preference = _context.PrefsDb.FirstOrDefault(p => p.Name == name);
            int ret = 0;
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
            return ret; 
        }

        public void AddOrUpdateIntPreference(string name, int value)
        {
            string string_val = value.ToString();
            AddOrUpdateStringPreference(name, string_val);
        }

        public void AddOrUpdateStringPreference(string name, string value)
        {
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
