using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

namespace Aperomero.TrainingPlan.SceneMainManagement.MainCalendarView
{

    public class MainCalendarViewWeekDisplay : MonoBehaviour
    {

        #region Variables

        [Tooltip("The objects representing a day in the scene")]
        public MainCalendarViewDayDisplay[] daysDisplay = new MainCalendarViewDayDisplay[7];

        [Tooltip("The type of the training for this week")]
        public TMP_Dropdown trainingType;

        [Tooltip("The text box to write the numbre of the week")]
        public TMP_Text weekMonthText;

        [Tooltip("The panel to change the color")]
        public GameObject gameObjectPanel;

        public Color noTrainingWeekColor;
        public Color baseWeekColor;
        public Color restWeekColor;

        // The scene manager
        private MainCalendarViewSceneManager sceneManager;

        #endregion

        #region Setters

        /// <summary>
        /// Set the text for the month display and also set the display for all days in the week
        /// </summary>
        /// <param name="date">The first day of the week in this display</param>
        public void SetFirstDayDate(DateTime date)
        {
            for (int i = 0; i < daysDisplay.Length; i++)
                daysDisplay[i].SetDateDay(date.AddDays(i));
            weekMonthText.text = DateOperations.GetMonthFrench(date);
            if (!date.Month.Equals(date.AddDays(6).Month))
                weekMonthText.text += " - " + DateOperations.GetMonthFrench(date.AddDays(7));
        }

        /// <summary>
        /// Set the display with a new value of training type
        /// </summary>
        /// <param name="newValue"></param>
        public void SetTrainingTypeDisplay(int newValue)
        {
            trainingType.value = newValue;
            ChangePanelColor(newValue);
        }

        public void SetManager(MainCalendarViewSceneManager manager)
        {
            sceneManager = manager;
        }

        #endregion

        #region Getters

        /// <summary>
        /// Return the date represented by a specific day of this week
        /// </summary>
        /// <param name="weekDay">The number of the day of the week, Monday = 0, Sunday = 6</param>
        /// <returns></returns>
        public DateTime GetDateOfTheDay(int weekDay = 0)
        {
            return daysDisplay[weekDay].GetDateOfTheDay();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Change the color of the panel
        /// </summary>
        /// <param name="newValue"></param>
        private void ChangePanelColor(int newValue)
        {
            Material panel = gameObjectPanel.GetComponent<MeshRenderer>().material;
            switch (newValue)
            {
                case 0:
                    panel.color = noTrainingWeekColor;
                    break;
                case 1:
                    panel.color = baseWeekColor;
                    break;
                case 2:
                    panel.color = restWeekColor;
                    break;
            }
        }

        #endregion

        #region Buttons Interactions

        public void ChangingTrainingType()
        {
            try
            {
                sceneManager.ChangeWeekTrainingType(daysDisplay[0].GetDateOfTheDay(), trainingType.value);
                ChangePanelColor(trainingType.value);
            }
            catch (NullReferenceException)
            {

            }
        }

        #endregion

    }

}
