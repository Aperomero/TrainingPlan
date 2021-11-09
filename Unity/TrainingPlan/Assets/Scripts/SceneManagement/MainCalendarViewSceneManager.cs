using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Aperomero.TrainingPlan.UserObjects;
using Aperomero.TrainingPlan.SceneMainManagement.MainCalendarView;

namespace Aperomero.TrainingPlan.SceneMainManagement
{

    public class MainCalendarViewSceneManager : MonoBehaviour
    {

        #region Variables

        [Tooltip("The text box for welcoming the user")]
        public TMP_Text welcomeUserText;

        [Tooltip("The text box to display the year currently displayed in the calendar")]
        public TMP_Text yearTextBox;

        [Tooltip("The displays for the weeks displayed in the scene")]
        public List<MainCalendarViewWeekDisplay> weeksDisplay;

        // The profile to be displayed
        private UserProfile profile = null;

        #endregion

        #region Unity Methods

        private void Start()
        {
            profile = CrossSceneParameters.currentProfile;
            welcomeUserText.text = "Bienvenue " + profile.GetUserName() + " !";
            SetFirstDayDisplayed(DateTime.Now.AddDays(-7));
            foreach (MainCalendarViewWeekDisplay week in weeksDisplay)
                week.SetManager(this);
        }

        #endregion

        #region Public Methods

        public void ChangeWeekTrainingType(DateTime weekFirstDay, int trainingType)
        {

            // Convert the int in a weektype value
            WeekType weekTrainingType = WeekType.Base;
            switch (trainingType)
            {
                case 1:
                    weekTrainingType = WeekType.Base;
                    break;
                case 2:
                    weekTrainingType = WeekType.Repos;
                    break;
            }

            try
            {
                if (trainingType == 0)
                {

                }
                else
                {
                    profile.GetWeek(weekFirstDay.Date).SetTrainingType(weekTrainingType);
                }
            } 
            catch (NullReferenceException)
            {
                if (trainingType == 0)
                {

                }
                else
                {
                    TrainingWeek newWeek = new TrainingWeek(weekTrainingType, weekFirstDay.Date);
                    profile.AddTrainingWeek(newWeek);
                }
            }
            
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Set the date for the display of all weeks displayed in the scene
        /// </summary>
        /// <param name="date"></param>
        private void SetFirstDayDisplayed(DateTime date)
        {

            DateTime correctedFirstDate = date.Date.AddDays(-((int)date.DayOfWeek) + 1);
            yearTextBox.text = correctedFirstDate.Year.ToString();
            int counter = 0;
            foreach (MainCalendarViewWeekDisplay week in weeksDisplay)
            {

                // Set the day
                week.SetFirstDayDate(correctedFirstDate.AddDays(7 * counter));

                // Set the type if the week already exists in the profile
                try
                {
                    week.SetTrainingTypeDisplay((int)profile.GetWeek(correctedFirstDate.AddDays(7 * counter)).GetTrainingType() + 1);
                }
                catch (NullReferenceException)
                {
                    week.SetTrainingTypeDisplay(0);
                }
                
                counter++;

            }

            if (!correctedFirstDate.AddDays((weeksDisplay.Count * 7) - 1).Year.Equals(correctedFirstDate.Year))
                yearTextBox.text += " - " + correctedFirstDate.AddDays((weeksDisplay.Count * 7) - 1).Year.ToString();

        }

        #endregion

        #region Buttons Interaction

        /// <summary>
        /// Close the application, on runtime only
        /// </summary>
        public void QuitApplication()
        {
            Application.Quit();
        }

        /// <summary>
        /// Open the scene welcome
        /// </summary>
        public void BackToWelcomePage()
        {
            SceneManager.LoadScene("Welcome");
        }

        /// <summary>
        /// Go one week further in the display
        /// </summary>
        public void DisplayNextWeek()
        {
            SetFirstDayDisplayed(weeksDisplay[0].GetDateOfTheDay().AddDays(7));
        }

        /// <summary>
        /// Display the previous week
        /// </summary>
        public void DisplayPreviousWeek()
        {
            SetFirstDayDisplayed(weeksDisplay[0].GetDateOfTheDay().AddDays(-7));
        }

        /// <summary>
        /// Save the view to the profile file
        /// </summary>
        public void SaveProfileButton()
        {
            BinarySerialization.WriteToBinaryFile<UserProfile>("Saves/Profiles/" + profile.GetUserName() + ".bin", profile, false);
        }

        #endregion

    }

}
