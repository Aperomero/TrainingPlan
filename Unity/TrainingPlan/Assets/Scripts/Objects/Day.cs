using System;
using System.Collections;
using System.Collections.Generic;

namespace Aperomero.TrainingPlan.Objects
{

    [Serializable]
    public class Day
    {

        #region Variables

        // The date of the day
        private DateTime dayDate;

        #endregion

        #region Constructors

        public Day(DateTime date)
        {
            dayDate = date;
        }

        #endregion

    }

}
