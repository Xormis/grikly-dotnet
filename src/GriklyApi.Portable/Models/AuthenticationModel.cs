using System;

namespace GriklyApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// Gets or sets the access_token.
        /// </summary>
        /// <value>
        /// The access_token.
        /// </value>
        public string access_token { get; set; }
        /// <summary>
        /// Gets or sets the token_type.
        /// </summary>
        /// <value>
        /// The token_type.
        /// </value>
        public string token_type { get; set; }
        /// <summary>
        /// Gets or sets the expires_in.
        /// </summary>
        /// <value>
        /// The expires_in.
        /// </value>
        public int expires_in { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string userName { get; set; }
        /// <summary>
        /// Gets or sets the issued.
        /// </summary>
        /// <value>
        /// The issued.
        /// </value>
        public DateTime issued { get; set; }
        /// <summary>
        /// Gets or sets the expires.
        /// </summary>
        /// <value>
        /// The expires.
        /// </value>
        public DateTime expires { get; set; }
    }
}