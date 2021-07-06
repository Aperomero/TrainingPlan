using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Aperomero.TrainingPlan.SceneManagement
{

    public class NewSeasonSceneManager : MonoBehaviour
    {

        #region Variables

        private string templatePath = "Assets/Resources/Seasons/SeasonTemplate.csv";
        private string parametersPath = "Assets/Resources/Parameters/ParametersTemplate.csv";

        #endregion

        #region Unity Methods

        private void Start()
        {

            if (File.Exists(templatePath) && File.Exists(parametersPath))
            {
                PrivateTools.TODO("Allow creation of new set of parameters");
            }
            else
            {
                Debug.LogError("Problems to found parameters and season templates");
            }
                        
        }

        #endregion

    }

}
