using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Aperomero.TrainingPlan.Objects;

namespace Aperomero.TrainingPlan.SeasonViews.Calendars
{

    public class WeekMonthView : MonoBehaviour
    {

        #region Variables

        // The object Week represented by this Game object
        private Week weekObject;

        [Tooltip("The 'Day' Game Objects of the week")]
        public DayMonthView[] daysInWeek = new DayMonthView[7];

        [Tooltip("The text box to display the number of the week")]
        public TextMeshProUGUI numWeekDisplay;

        #endregion

        #region Setters

        public void SetWeekObject(Week week)
        {
            weekObject = week;
            numWeekDisplay.text = "Semaine " + week.GetWeekNumber().ToString();
            for (int i = 0; i < 7; i++)
            {
                daysInWeek[i].SetDayObject(week.GetDay(i));
            }
        }

        #endregion

    }

}
