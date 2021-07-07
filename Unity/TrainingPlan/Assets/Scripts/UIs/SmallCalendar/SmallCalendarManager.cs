using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aperomero.TrainingPlan.UIs.SmallCalendar
{

    public class SmallCalendarManager : MonoBehaviour
    {

        #region Variables

        [Tooltip("The textbox to display the month")]
        public TextMeshProUGUI monthText;

        [Tooltip("The weeks of the small calendar from top to bottom")]
        public SmallCalendarWeek[] weeks = new SmallCalendarWeek[6];

        // The selected date (starts with the current date)
        private DateTime selectedDate;

        // The object asking for a date
        private DateInputField input;

        #endregion

        #region Unity Methods

        private void Start()
        {
            selectedDate = DateTime.Now;
            UpdateMonth(selectedDate);
            foreach (SmallCalendarWeek week in weeks)
                week.SetCalendarManager(this);
        }

        #endregion

        #region Public Methods

        public void SetSelectedDate(DateTime date)
        {
            selectedDate = date;
            UpdateMonth(selectedDate);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Update the display of the month
        /// </summary>
        /// <param name="date">The selected date</param>
        private void UpdateMonth(DateTime date)
        {
            string year = date.Year.ToString();
            string month = "";

            switch (date.Month)
            {
                case 1:
                    month = "Janvier";
                    break;
                case 2:
                    month = "Février";
                    break;
                case 3:
                    month = "Mars";
                    break;
                case 4:
                    month = "Avril";
                    break;
                case 5:
                    month = "Mai";
                    break;
                case 6:
                    month = "Juin";
                    break;
                case 7:
                    month = "Juillet";
                    break;
                case 8:
                    month = "Août";
                    break;
                case 9:
                    month = "Septembre";
                    break;
                case 10:
                    month = "Octobre";
                    break;
                case 11:
                    month = "Novembre";
                    break;
                case 12:
                    month = "Décembre";
                    break;
            }

            monthText.text = month + " " + year;

            DateTime firstDayOfTheMonth = date.AddDays(-(date.Day - 1));
            DateTime firstDayDisplay = firstDayOfTheMonth;

            switch (firstDayOfTheMonth.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    firstDayDisplay = firstDayOfTheMonth.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    firstDayDisplay = firstDayOfTheMonth.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    firstDayDisplay = firstDayOfTheMonth.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    firstDayDisplay = firstDayOfTheMonth.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    firstDayDisplay = firstDayOfTheMonth.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    firstDayDisplay = firstDayOfTheMonth.AddDays(-6);
                    break;
            }

            int counter = 0;
            foreach(SmallCalendarWeek week in weeks)
            {
                week.UpdateFirstDayDate(firstDayDisplay.AddDays(7 * counter));
                week.SetSelectedDate(selectedDate);
                counter++;
            }

        }

        #endregion

        #region Setters

        public void SetInput(DateInputField inputField)
        {
            input = inputField;
        }

        #endregion

        #region Buttons Reactions

        public void NextMonth()
        {
            selectedDate = selectedDate.AddMonths(1);
            UpdateMonth(selectedDate);
        }

        public void PreviousMonth()
        {
            selectedDate = selectedDate.AddMonths(-1);
            UpdateMonth(selectedDate);
        }

        public void ValidateButton()
        {
            input.SetDate(selectedDate);
            Destroy(gameObject);
        }

        #endregion

    }

}
