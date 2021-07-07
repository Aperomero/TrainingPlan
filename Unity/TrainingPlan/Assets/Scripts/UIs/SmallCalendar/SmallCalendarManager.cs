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

        // The selected date (starts with the current date)
        private DateTime selectedDate = DateTime.Now;

        #endregion

        #region Unity Methods

        private void Start()
        {
            UpdateMonth(selectedDate);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Update the display of the month text
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
        }

        #endregion

    }

}
