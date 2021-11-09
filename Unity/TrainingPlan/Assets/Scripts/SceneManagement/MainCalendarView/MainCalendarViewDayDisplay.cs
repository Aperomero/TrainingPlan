using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Aperomero.TrainingPlan.SceneMainManagement.MainCalendarView
{

    public class MainCalendarViewDayDisplay : MonoBehaviour
    {

        #region Variables

        [Tooltip("The text box displaying the date of the day")]
        public TMP_Text dateDisplay;

        // The date that this day represents
        private DateTime dateOfThisDay;

        #endregion

        #region Setters

        /// <summary>
        /// Set the display of the date for this day
        /// </summary>
        /// <param name="date">The date of this day</param>
        public void SetDateDay(DateTime date)
        {
            string display = date.Day.ToString();
            dateDisplay.text = display;
            dateOfThisDay = date.Date;
        }

        #endregion

        #region Getters

        /// <summary>
        /// Get the date that this day represents
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateOfTheDay()
        {
            return dateOfThisDay;
        }

        #endregion

    }

}
