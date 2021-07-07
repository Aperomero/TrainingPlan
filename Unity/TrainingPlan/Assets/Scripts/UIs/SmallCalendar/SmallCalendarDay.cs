using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Aperomero.TrainingPlan.UIs.SmallCalendar
{

    public class SmallCalendarDay : MonoBehaviour
    {

        #region Variables

        [Tooltip("The text box of the cell")]
        public TextMeshProUGUI cellText;

        [Tooltip("The sprite used when the selected date is NOT the cell one")]
        public Sprite normalSprite;

        [Tooltip("The sprite used when the selected date IS the cell one")]
        public Sprite selectedDateSprite;

        // The date that this cell represents
        private DateTime cellDate;

        // The date currently selected in the small calendar
        private DateTime selectedDate;

        // The calendar manager
        private SmallCalendarManager calendarManager;

        #endregion

        #region Unity Methods

        private void OnMouseDown()
        {
            calendarManager.SetSelectedDate(cellDate);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Update the date represented by the cell
        /// </summary>
        /// <param name="date">The new date of the cell</param>
        public void UpdateCellDate(DateTime date)
        {
            cellText.text = date.Day.ToString();
            cellDate = date;
        }

        #endregion

        #region Setters

        public void SetSelectedDate(DateTime date)
        {
            selectedDate = date;
            if (selectedDate.Date.Equals(cellDate.Date))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = selectedDateSprite;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            }
        }

        public void SetCalendarManager(SmallCalendarManager manager)
        {
            calendarManager = manager;
        }

        #endregion

    }

}
