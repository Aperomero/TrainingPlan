
using System;

namespace Aperomero.TrainingPlan.UserObjects
{

    /// <summary>
    /// The class grouping all informations about the user
    /// </summary>
    [Serializable]
    public class UserProfile
    {

        #region Variables

        // The name of the user
        private string username;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new profile
        /// </summary>
        /// <param name="username">The name of the user</param>
        public UserProfile(string username)
        {
            this.username = username;
        }

        #endregion

        #region Setters

        public void SetUserName(string name)
        {
            username = name;
        }

        #endregion

        #region Getters

        public string GetUserName()
        {
            return username;
        }

        #endregion

    }

}
