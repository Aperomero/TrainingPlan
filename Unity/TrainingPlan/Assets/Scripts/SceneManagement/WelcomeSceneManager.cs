using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using Aperomero.TrainingPlan.UserObjects;

namespace Aperomero.TrainingPlan.SceneMainManagement
{

    /// <summary>
    /// The script managing the "welcome" scene
    /// </summary>
    public class WelcomeSceneManager : MonoBehaviour
    {

        #region Variables

        [Header("Pages")]
        [Tooltip("The game object (in the canvas) storing all UIs for the welcome page")]
        public GameObject welcomePage;

        [Tooltip("The game object (in the canvas) storing all UIs for the creation of a new profile")]
        public GameObject createNewProfilePage;

        [Header("UIs for welcome page")]
        [Tooltip("The dropdown object to display all availables profiles")]
        public TMP_Dropdown profileChoice;

        [Header("UIs for new profile")]
        [Tooltip("The input field for the name of the user for a new profile")]
        public TMP_InputField username;

        [Tooltip("The warning message for the user name")]
        public TMP_Text warningUsername;

        #endregion

        #region Unity Methods

        private void Start()
        {
            OpenWelcomePage();
        }

        #endregion

        #region Buttons Interaction

        /// <summary>
        /// Displays only the UIs of the new profile page
        /// </summary>
        public void OpenNewProfilePage()
        {
            welcomePage.SetActive(false);
            createNewProfilePage.SetActive(true);

            username.text = "";
            warningUsername.gameObject.SetActive(false);
        }

        /// <summary>
        /// Displays only the UIs of the welcome page
        /// </summary>
        public void OpenWelcomePage()
        {
            if (!Directory.Exists("Saves"))
                Directory.CreateDirectory("Saves");
            if (!Directory.Exists("Saves/Profiles"))
                Directory.CreateDirectory("Saves/Profiles");

            List<string> choices = new List<string>();
            foreach (string file in Directory.GetFiles("Saves/Profiles"))
            {
                string correctedFile = file.Substring(15);
                correctedFile = correctedFile.Substring(0, correctedFile.Length - 4);
                choices.Add(correctedFile);
            }

            profileChoice.ClearOptions();
            profileChoice.AddOptions(choices);

            welcomePage.SetActive(true);
            createNewProfilePage.SetActive(false);
        }

        /// <summary>
        /// Create a new profile if all required information are provided
        /// </summary>
        public void ValidateCreateNewProfile()
        {
            bool allowedToCreate = true;
            if (username.text == "")
            {
                warningUsername.gameObject.SetActive(true);
                allowedToCreate = false;
            }

            if (allowedToCreate)
            {
                UserProfile newProfile = new UserProfile(username.text);
                BinarySerialization.WriteToBinaryFile<UserProfile>("Saves/Profiles/" + username.text + ".bin", newProfile);
                OpenWelcomePage();
            }
        }

        /// <summary>
        /// Close the application
        /// </summary>
        public void ExitApplication()
        {
            Application.Quit();
        }

        /// <summary>
        /// Open the main calendar view by loading a new scene
        /// </summary>
        public void OpenMainCalendarView()
        {
            if (profileChoice.options[profileChoice.value].text != "")
            {
                CrossSceneParameters.currentProfile = BinarySerialization.ReadFromBinaryFile<UserProfile>("Saves/Profiles/" + profileChoice.options[profileChoice.value].text + ".bin");
                SceneManager.LoadScene("MainCalendarView");
            }
        }

        #endregion

    }

}
