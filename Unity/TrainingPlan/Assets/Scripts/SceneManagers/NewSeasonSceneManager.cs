using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aperomero.TrainingPlan.SceneManagement
{

    public class NewSeasonSceneManager : MonoBehaviour
    {

        #region Buttons Interactions

        public void BackButton()
        {
            SceneManager.LoadScene("WelcomeScene");
        }

        #endregion

    }

}
