using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Aperomero.TrainingPlan.UIs;
using Aperomero.TrainingPlan.Objects;

namespace Aperomero.TrainingPlan.SceneManagement
{

    public class NewSeasonSceneManager : MonoBehaviour
    {

        #region Variables

        [Tooltip("The text box with the season name")]
        public TMP_InputField inputSeasonName;

        [Tooltip("The object with the text box with the starting date")]
        public DateInputField inputStartingDate;

        #endregion

        #region Buttons Interactions

        public void BackButton()
        {
            SceneManager.LoadScene("WelcomeScene");
        }

        public void ValidateButton()
        {
            Season newSeason = new Season(inputSeasonName.text, inputStartingDate.GetSelectedDate(), new Parameters());
            CrossSceneParameters.openedSeason = newSeason;
            SceneManager.LoadScene("MonthView");
            // BinarySerialization.WriteToBinaryFile<Season>(newSeason.GetSaveFilePath(), newSeason);
        }

        #endregion

    }

}
