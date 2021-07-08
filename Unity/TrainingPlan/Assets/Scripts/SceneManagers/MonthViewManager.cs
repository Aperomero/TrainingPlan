using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aperomero.TrainingPlan.Objects;
using Aperomero.TrainingPlan.SeasonViews.Calendars;

namespace Aperomero.TrainingPlan.SceneManagement
{

    public class MonthViewManager : MonoBehaviour
    {

        #region Variables

        // The season opened
        private Season displayedSeason;

        [Tooltip("The weeks display")]
        public WeekMonthView[] weeksDisplayed = new WeekMonthView[5];

        #endregion

        #region Unity Methods

        private void Start()
        {
            displayedSeason = CrossSceneParameters.openedSeason;
            for (int i = 0; i < 5; i++)
            {
                weeksDisplayed[i].SetWeekObject(displayedSeason.GetWeek(i));
            }
        }

        #endregion

    }

}
