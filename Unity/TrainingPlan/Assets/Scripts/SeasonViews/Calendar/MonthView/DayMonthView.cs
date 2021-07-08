using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Aperomero.TrainingPlan.Objects;

namespace Aperomero.TrainingPlan.SeasonViews.Calendars
{

    public class DayMonthView : MonoBehaviour
    {

        #region Variables

        // The object Day represented by this Game Object
        private Day dayObject;

        // The text box to display the date
        public TextMeshProUGUI dateDisplay;

        #endregion

        #region Setters

        public void SetDayObject(Day day)
        {
            dayObject = day;
            dateDisplay.text = day.GetDate().ToShortDateString();
        }

        #endregion

    }

}
