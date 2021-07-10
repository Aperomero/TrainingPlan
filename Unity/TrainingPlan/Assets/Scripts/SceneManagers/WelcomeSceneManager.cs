using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Aperomero.TrainingPlan.Objects;

namespace Aperomero.TrainingPlan.SceneManagement
{

    public class WelcomeSceneManager : MonoBehaviour
    {

        #region Variables

        [Tooltip("The dropdown object displaying all the available seasons")]
        public TMP_Dropdown seasonChoice;

        #endregion

        #region Unity Methods

        private void Start()
        {
            if (!Directory.Exists("Saves"))
                Directory.CreateDirectory("Saves");
            if (!Directory.Exists("Saves/Seasons"))
                Directory.CreateDirectory("Saves/Seasons");

            List<string> choices = new List<string>();
            foreach (string file in Directory.GetFiles("Saves/Seasons"))
            {
                choices.Add(file);
            }

            seasonChoice.AddOptions(choices);
        }

        #endregion

        #region Buttons Reactions

        public void CreateNewSeason()
        {
            SceneManager.LoadScene("NewSeasonScene");
        }

        public void LoadSeason()
        {
            //Season loadedSeason = BinarySerialization.ReadFromBinaryFile<Season>("Assets/Resources/Seasons/test.bin");
            //CrossSceneParameters.openedSeason = loadedSeason;
            //SceneManager.LoadScene("MonthView");

        }

        #endregion

    }

}