using System;
using System.Collections;
using System.Collections.Generic;

namespace Aperomero.TrainingPlan.Objects
{

    [Serializable]
    public class Week
    {

        #region Variables

        // The days of the week
        private Day[] days;

        #endregion

        #region Constructors

        public Week(DateTime startingDate)
        {
            days = new Day[7];
            for (int i = 0; i < 7; i++)
            {
                days[i] = new Day(startingDate.AddDays(i));
            }
        }

        #endregion

    }

}
