using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Aperomero.TrainingPlan.UserObjects;

namespace Aperomero.TrainingPlan.SceneMainManagement
{

    public class MainCalendarViewSceneManager : MonoBehaviour
    {

        #region Variables

        [Tooltip("The text box for welcoming the user")]
        public TMP_Text welcomeUserText;

        // The profile to be displayed
        private UserProfile profile;

        #endregion

        #region Unity Methods

        private void Start()
        {
            profile = CrossSceneParameters.currentProfile;
            welcomeUserText.text = "Bienvenue " + profile.GetUserName() + " !";
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

        #endregion

    }

}
