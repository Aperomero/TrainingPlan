using System;

namespace Aperomero.TrainingPlan.UserObjects
{

    [Serializable]
    public class TrainingWeek
    {

        #region Variables

        // The type of the training for this week
        private WeekType trainingType;

        // The first day of the week
        private DateTime startDate;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new training week
        /// </summary>
        /// <param name="trainingType">The type of the training for this week</param>
        /// <param name="startDate">The first day of the week</param>
        public TrainingWeek(WeekType trainingType, DateTime startDate)
        {
            this.trainingType = trainingType;
            this.startDate = startDate.Date;
        }

        #endregion

        #region Setters

        public void SetTrainingType(WeekType trainingType)
        {
            this.trainingType = trainingType;
        }

        #endregion

        #region Getters

        public DateTime GetStartDay()
        {
            return startDate;
        }

        public WeekType GetTrainingType()
        {
            return trainingType;
        }

        #endregion

    }

}
