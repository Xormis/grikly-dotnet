// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGriklyApi.cs" company="">
//   
// </copyright>
// <summary>
//   The GriklyApi interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Grikly
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GriklyApi.Models;

    /// <summary>
    /// The GriklyApi interface.
    /// </summary>
    public interface IGriklyClient : IDisposable
    {
        #region Public Properties

        /// <summary>
        /// The API Key that is used to validate requests to the server.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        string ApiKey { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> ChangePassword(string oldPassword, string newPassword, CancellationToken token);
        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse<AuthenticationModel>> Login(string email, string password, CancellationToken token);

        /// <summary>
        /// Add the credentials of the user to make authenticated requests
        /// </summary>
        /// <param name="bearerToken">The bearer token.</param>
        void AddCredentials(string bearerToken);

        /// <summary>
        /// Determines whether [is credentials set].
        /// </summary>
        /// <returns></returns>
        bool IsCredentialsSet();
        /// <summary>
        /// Creates the card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<object>> CreateCard(Card card, CancellationToken token);

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> CreateContact(Contact contact, CancellationToken token);

        /// <summary>
        /// Deletes the card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> DeleteCard(Guid id, CancellationToken token);

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> DeleteContact(Guid id, CancellationToken token);

        /// <summary>
        /// Emails the exist.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<bool>> EmailExist(string email, CancellationToken token);

        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> GetCard(Guid id, CancellationToken token);

        /// <summary>
        /// The get contacts.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<PagingModel<Card>>> GetContacts(
            string searchText,
            int page,
            int pageSize,
            CancellationToken token);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        //Task<IHttpResponse<User>> GetUser(Guid id, CancellationToken token);

        Task<IHttpResponse<User>> GetCurrentUserInfo(CancellationToken token);

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse> Register(RegisterModel register, CancellationToken token);

        /// <summary>
        /// Recovers the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> Recover(string email, CancellationToken token);
        /// <summary>
        /// Remove the credentials of the user for making authenticated requests
        /// </summary>
        void RemoveCredentials();

        /// <summary>
        /// Sends the card.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="model">The model.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> SendCard(Guid id, SendCardModel model, CancellationToken token);

        /// <summary>
        /// Updates the card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> UpdateCard(Card card, CancellationToken token);

        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<Card>> UpdateContact(Contact contact, CancellationToken token);

        /// <summary>
        /// Uploads the profile image.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        Task<IHttpResponse<string>> UploadProfileImage(byte[] data, CancellationToken token);


        /// <summary>
        /// Confirms the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="code">The code.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> ConfirmEmail(string email, string code, CancellationToken token);
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="code">The code.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmPassword">The confirm password.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> ResetPassword(string email, string code, string password, string confirmPassword, CancellationToken token);

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="eventModel">The event model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> CreateEvent(EventModel eventModel, CancellationToken token);

        /// <summary>
        /// Resends the confirmation.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> ResendConfirmation(string email, CancellationToken token);
        #endregion

        /// <summary>
        /// Gets the event by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse<EventModel>> GetEventById(Guid id, CancellationToken token);

        /// <summary>
        /// Determines whether the currently logged in user has confirmed their email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse<bool>> IsUserConfirmed(CancellationToken token);
    }
}