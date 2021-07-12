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
                string correctedFile = file.Substring(14);
                correctedFile = correctedFile.Substring(0, correctedFile.Length - 4);
                choices.Add(correctedFile);
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
            string binFile = "Saves/Seasons/";
            binFile += seasonChoice.options[seasonChoice.value].text;
            binFile += ".bin";
            Season loadedSeason = BinarySerialization.ReadFromBinaryFile<Season>(binFile);
            CrossSceneParameters.openedSeason = loadedSeason;
            SceneManager.LoadScene("MonthView");
        }

        #endregion

    }

}