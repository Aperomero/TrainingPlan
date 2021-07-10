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
            PrivateTools.Debugging(displayedSeason.GetSeasonName());
            DisplayFromWeek(0);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set all the weeks displayed
        /// </summary>
        /// <param name="weekNum">The first week displayed</param>
        private void DisplayFromWeek(int weekNum)
        {
            for (int i = 0; i < 5; i++)
            {
                weeksDisplayed[i].SetWeekObject(displayedSeason.GetWeek(i + weekNum));
            }
        }

        #endregion

        #region Buttons Reaction

        public void SaveButton()
        {
            BinarySerialization.WriteToBinaryFile(displayedSeason.GetSaveFilePath(), displayedSeason);
        }

        public void DownButton()
        {
            if (weeksDisplayed[0].GetWeekNumber() < 48)
            {
                DisplayFromWeek(weeksDisplayed[0].GetWeekNumber());
            }
        }

        public void UpButton()
        {
            if (weeksDisplayed[0].GetWeekNumber() > 1)
            {
                DisplayFromWeek(weeksDisplayed[0].GetWeekNumber() - 2);
            }
        }

        #endregion

    }

}
