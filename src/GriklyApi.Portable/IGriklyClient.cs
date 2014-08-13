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
    public interface IGriklyClient
    {
        #region Public Properties

        /// <summary>
        ///     The API Key that is used to validate requests to the server.
        /// </summary>
        string ApiKey { get; }

        #endregion

        #region Public Methods and Operators

        Task<IHttpResponse> ChangePassword(string oldPassword, string newPassword, CancellationToken token);
        Task<IHttpResponse<AuthenticationModel>> Login(string email, string password, CancellationToken token);

        /// <summary>
        /// Add the credentials of the user to make authenticated requests
        /// </summary>
        /// <param name="email">
        /// the email
        /// </param>
        /// <param name="password">
        /// the password
        /// </param>
        void AddCredentials(string bearerToken);

        bool IsCredentialsSet();
        /// <summary>
        /// Creates the card.
        /// </summary>
        /// <param name="card">
        /// The card.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<object>> CreateCard(Card card, CancellationToken token);

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="contact">
        /// The contact.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> CreateContact(Contact contact, CancellationToken token);

        /// <summary>
        /// Deletes the card.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> DeleteCard(Guid id, CancellationToken token);

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> DeleteContact(Guid id, CancellationToken token);

        /// <summary>
        /// </summary>
        /// <param name="email">
        /// </param>
        /// <param name="token">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<bool>> EmailExist(string email, CancellationToken token);

        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> GetCard(Guid id, CancellationToken token);

        /// <summary>
        /// The get contacts.
        /// </summary>
        /// <param name="searchText">
        /// The search text.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<PagingModel<Card>>> GetContacts(
            string searchText, 
            int page, 
            int pageSize, 
            CancellationToken token);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        //Task<IHttpResponse<User>> GetUser(Guid id, CancellationToken token);

        Task<IHttpResponse<User>> GetCurrentUserInfo(CancellationToken token);

        /// <summary>
        /// </summary>
        /// <param name="register">
        /// </param>
        /// <param name="token">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse> Register(RegisterModel register, CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<IHttpResponse> Recover(string email, CancellationToken token);
        /// <summary>
        ///     Remove the credentials of the user for making authenticated requests
        /// </summary>
        void RemoveCredentials();

        /// <summary>
        /// Sends the card.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> SendCard(Guid id, SendCardModel model, CancellationToken token);

        /// <summary>
        /// Updates the card.
        /// </summary>
        /// <param name="card">
        /// The card.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> UpdateCard(Card card, CancellationToken token);

        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="contact">
        /// The contact.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<Card>> UpdateContact(Contact contact, CancellationToken token);

        /// <summary>
        /// Uploads the profile image.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="contentType">
        /// Type of the content.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IHttpResponse<string>> UploadProfileImage(byte[] data, CancellationToken token);

        #endregion

        Task<IHttpResponse> ConfirmEmail(string email, string code, CancellationToken token);
        Task<IHttpResponse> ResetPassword(string email, string code, string password, string confirmPassword, CancellationToken token);

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="eventModel">The event model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IHttpResponse> CreateEvent(EventModel eventModel, CancellationToken token);

        Task<IHttpResponse> ResendConfirmation(string email, CancellationToken token);
    }
}