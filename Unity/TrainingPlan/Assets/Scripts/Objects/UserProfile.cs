
using System;
using System.Collections.Generic;

namespace Aperomero.TrainingPlan.UserObjects
{

    /// <summary>
    /// The class grouping all informations about the user
    /// </summary>
    [Serializable]
    public class UserProfile
    {

        #region Variables

        // The name of the user
        private string username;

        // The list of the weeks that the user has defined or computed
        private List<TrainingWeek> weeks;

        // The list of season goals of the user
        private List<SeasonGoal> goals;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new profile
        /// </summary>
        /// <param name="username">The name of the user</param>
        public UserProfile(string username)
        {
            this.username = username;
            weeks = new List<TrainingWeek>();
        }

        #endregion

        #region Setters

        public void SetUserName(string name)
        {
            username = name;
        }

        public void AddTrainingWeek(TrainingWeek week)
        {
            if (weeks.Count == 0)
                weeks.Add(week);
            else
            {
                bool insert = false;
                int counter = 0;
                while (!insert && counter < weeks.Count)
                {
                    if (weeks[counter].GetStartDay() < week.GetStartDay())
                    {
                        weeks.Insert(counter, week);
                        insert = true;
                    }
                    counter++;
                }
                if (!insert)
                    weeks.Add(week);
            }
        }

        #endregion

        #region Getters

        public string GetUserName()
        {
            return username;
        }

        /// <summary>
        /// Find a week in the list of the training weeks
        /// </summary>
        /// <param name="startingDay">The first day of the week wanted</param>
        /// <returns>The week if it exists, null if not</returns>
        public TrainingWeek GetWeek(DateTime startingDay)
        {
            // If no weeks exist yet, return null
            if (weeks.Count == 0)
                return null;

            // Return the corresponding week if you find it
            DateTime correctedDate = startingDay.Date;
            int count = 0;
            while (count < weeks.Count)
            {
                if (weeks[count].GetStartDay().Equals(correctedDate))
                    return weeks[count];
                count++;
            }

            // Return null, if no week corresponds
            return null;
        }

        #endregion

    }

}
