using System;
using System.Collections;
using System.Collections.Generic;

namespace Aperomero.TrainingPlan.Objects
{

    /// <summary>
    /// A training season
    /// </summary>
    public class Season
    {

        #region Variables

        // The season name
        private string name;

        // The first day of the season
        private DateTime startingDay;

        // The parameter set link to this season
        private Parameters parameters;

        // The table of weeks (52) that this season contains
        private Week[] weeks;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new season of 52 empty weeks
        /// </summary>
        /// <param name="name">The name of the season</param>
        /// <param name="startingDay">The first day of the season</param>
        /// <param name="parameters">The parameters set linked to this season</param>
        public Season(string name, DateTime startingDay, Parameters parameters)
        {
            this.name = name;
            this.startingDay = startingDay;
            this.parameters = parameters;
            weeks = new Week[52];
        }

        #endregion

    }

}
