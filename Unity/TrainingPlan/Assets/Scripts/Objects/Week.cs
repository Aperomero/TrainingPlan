using System;
using System.Collections;
using System.Collections.Generic;

namespace Aperomero.TrainingPlan.Objects
{

    [Serializable]
    public class Week
    {

        #region Variables

        // The week number in the calendar
        private int weekNumber;

        // The days of the week
        private Day[] days;

        #endregion

        #region Constructors

        public Week(int num, DateTime startingDate)
        {
            weekNumber = num;

            days = new Day[7];
            for (int i = 0; i < 7; i++)
            {
                days[i] = new Day(startingDate.AddDays(i));
            }
        }

        #endregion

        #region Getters

        public int GetWeekNumber()
        {
            return weekNumber;
        }

        public Day GetDay(int i)
        {
            return days[i];
        }

        public DateTime GetStartingDate()
        {
            return days[0].GetDate();
        }

        #endregion

    }

}
