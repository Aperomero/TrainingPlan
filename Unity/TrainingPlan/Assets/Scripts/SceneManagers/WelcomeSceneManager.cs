using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aperomero.TrainingPlan.SceneManagement
{

    public class WelcomeSceneManager : MonoBehaviour
    {

        #region Buttons Reactions

        public void CreateNewSeason()
        {
            SceneManager.LoadScene("NewSeasonScene");
        }

        #endregion

    }

}