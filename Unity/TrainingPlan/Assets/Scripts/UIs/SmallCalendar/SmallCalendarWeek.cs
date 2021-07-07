using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperomero.TrainingPlan.UIs.SmallCalendar
{

    public class SmallCalendarWeek : MonoBehaviour
    {

        #region Variables

        [Tooltip("The days of the week from left to right")]
        public SmallCalendarDay[] days = new SmallCalendarDay[7];

        #endregion

        #region Unity Methods

        private void Start()
        {
            int counter = 0;
            foreach(Transform child in transform)
            {
                days[counter] = child.gameObject.GetComponent<SmallCalendarDay>();
                counter++;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the date of all the days of the week with the first day date
        /// </summary>
        /// <param name="date">The date of the monday</param>
        public void UpdateFirstDayDate(DateTime date)
        {
            int counter = 0;
            foreach(SmallCalendarDay day in days)
            {
                day.UpdateCellDate(date.AddDays(counter));
                counter++;
            }
        }

        #endregion

        #region Setters

        public void SetSelectedDate(DateTime date)
        {
            foreach (SmallCalendarDay day in days)
            {
                day.SetSelectedDate(date);
            }
        }

        public void SetCalendarManager(SmallCalendarManager manager)
        {
            foreach (SmallCalendarDay day in days)
                day.SetCalendarManager(manager);
        }

        #endregion

    }

}
