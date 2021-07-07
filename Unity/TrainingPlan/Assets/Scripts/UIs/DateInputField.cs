using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Aperomero.TrainingPlan.UIs.SmallCalendar;

namespace Aperomero.TrainingPlan.UIs
{

    public class DateInputField : MonoBehaviour
    {

        #region Variables

        [Tooltip("The prefab of the small calendar")]
        public GameObject calendarPrefab;

        [Tooltip("The text box where the date will be displayed")]
        public TMP_InputField text;

        // The selected date
        private DateTime date;

        #endregion

        #region Setter

        public void SetDate(DateTime date)
        {
            this.date = date;
            text.text = date.Date.ToShortDateString();
        }

        #endregion

        #region Buttons

        public void OpenSmallCalendar()
        {
            GameObject calendar = Instantiate(calendarPrefab, new Vector3(0, 0, -1), Quaternion.identity);
            calendar.GetComponent<SmallCalendarManager>().SetInput(this);
        }

        #endregion

    }

}
