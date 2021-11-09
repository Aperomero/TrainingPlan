using System;

namespace Aperomero.TrainingPlan.UserObjects
{

    [Serializable]
    public class SeasonGoal
    {

        #region Variables

        // The name of the season
        private string seasonName;

        // The first day of the season (must be the first day of a week)
        private DateTime startingDate;

        // The number of weeks in this season
        private int weeksDuration;

        // The goal of the user for this season in number of km (equivalent running km)
        private double kilometersGoal;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new season with the parameters
        /// </summary>
        /// <param name="name">The season name</param>
        /// <param name="start">The first day of the season (must be the first day of a week)</param>
        /// <param name="weeks">The number of weeks in the season</param>
        /// <param name="goal">The goal in km of the season (equivalent running km)</param>
        public SeasonGoal(string name, DateTime start, int weeks, double goal)
        {
            seasonName = name;
            startingDate = start;
            weeksDuration = weeks;
            kilometersGoal = goal;
        }

        #endregion

    }

}
