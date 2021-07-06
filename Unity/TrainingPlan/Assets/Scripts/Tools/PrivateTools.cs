using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperomero.TrainingPlan
{

    public class PrivateTools : MonoBehaviour
    {

        public static void Debugging(string debug)
        {
            Debug.Log("<b>[Debug]</b> " + debug);
        }

        public static void TODO(string todo)
        {
            Debug.Log("<b>[TODO]</b> " + todo);
        }

    }

}
