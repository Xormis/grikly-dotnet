// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SendCardModel.cs" company="">
//   
// </copyright>
// <summary>
//   The send card model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GriklyApi.Models
{
    /// <summary>
    ///     The send card model.
    /// </summary>
    public class SendCardModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the emails.
        /// </summary>
        public List<string> Emails { get; set; }

        #endregion
    }
}