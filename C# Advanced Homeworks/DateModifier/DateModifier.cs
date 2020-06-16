using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace DateModifier
{
    class DateModifier
    {
        private List<DateTime> dates;

        public List<DateTime> Dates
        {
            get => dates;
            set => dates = value;
        }
        
        public DateModifier()
        {
            this.Dates = new List<DateTime>();
        }
        public void AddDate(DateTime date)
        {
            Dates.Add(date);
        }

        public int GetDifferenceOfTwoDays()
        {
            TimeSpan difference = Dates[1] - Dates[0];
            
            return int.Parse(difference.Days.ToString());
        }
    }
}
