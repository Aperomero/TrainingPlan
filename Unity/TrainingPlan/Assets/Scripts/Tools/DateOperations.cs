using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aperomero.TrainingPlan
{

    public static class DateOperations
    {

        /// <summary>
        /// Get the format DD/MM of the date
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns>DD/MM</returns>
        public static string GetDayMonthFormat(DateTime date)
        {
            string format = date.Day.ToString() + "/" + date.Month.ToString();
            return format;
        }

        /// <summary>
        /// Get the name of the month in french
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetMonthFrench(DateTime date)
        {
            string month = "";

            switch (date.Month)
            {
                case 1:
                    month = "Janvier";
                    break;
                case 2:
                    month = "Février";
                    break;
                case 3:
                    month = "Mars";
                    break;
                case 4:
                    month = "Avril";
                    break;
                case 5:
                    month = "Mai";
                    break;
                case 6:
                    month = "Juin";
                    break;
                case 7:
                    month = "Juillet";
                    break;
                case 8:
                    month = "Août";
                    break;
                case 9:
                    month = "Septembre";
                    break;
                case 10:
                    month = "Octobre";
                    break;
                case 11:
                    month = "Novembre";
                    break;
                case 12:
                    month = "Décembre";
                    break;
            }

            return month;
        }

    }

}
