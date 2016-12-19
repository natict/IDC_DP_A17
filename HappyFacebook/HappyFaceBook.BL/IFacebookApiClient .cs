using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using HappyFaceBook.BL.Exceptions;

namespace HappyFaceBook.BL
{
    public interface IFacebookApiClient
    {
        void LoginAndInit();

        /// <summary>
        /// Get the logged in user profile picture asynce
        /// </summary>
        /// <returns>Picture Url</returns>
        Task<string> GetLoggedInUserPictureUrlAsync();

        /// <summary>
        /// Get the logged in user name asynce
        /// </summary>
        /// <returns>User's Name</returns>
        Task<string> GetLoggedInUserNameAsync();

        /// <summary>
        /// Get the logged in user list of posts text
        /// </summary>
        /// <returns>List of posts text</returns>
        Task<List<string>> GetUserPostMessagesAsync();

        /// <summary>
        /// Get the logged in user list of posts
        /// </summary>
        /// <returns>List of posts on the users wall</returns>
        Task<List<FacebookEntity>> GetUserPostsAsync();

        /// <summary>
        /// Posts a status async
        /// </summary>
        /// <param name="i_Url">Picture to post url</param>
        /// <param name="i_Caption">PiPicture to post textparam>
        /// <returns></returns>
        Task PostStatusAsync(string i_StatusText, string i_PictureTitle = null);

        /// <summary>
        /// Posts a picture URL async, and refreshes the posts list
        /// </summary>
        /// <param name="i_Url">Picture to post url</param>
        /// <param name="i_Caption">PiPicture to post textparam>
        Task PostPictureURLAsync(string i_Url, string i_Caption);

        /// <summary>
        /// Posts a picture async, and refreshes the posts list
        /// </summary>
        /// <param name="i_PicturePath">Picture to post path</param>
        /// <param name="i_PictureTitle">Picture to post text</param>
        Task PostPictureAsync(string i_PicturePath, string i_PictureTitle);

        /// <summary>
        /// Get the logged in user's friends list async
        /// </summary>
        /// <returns>List of friends</returns>
        Task<List<FacebookEntity>> GetFriendsAsync();

        /// <summary>
        /// Get the logged in user's events list async
        /// </summary>
        /// <returns>Events list</returns>
        Task<List<FacebookEntity>> GetEventsAsync();

        /// <summary>
        /// Get the logged in user's checkins list async
        /// </summary>
        /// <returns>Checkins list</returns>
        List<FacebookEntity> GetCheckins();

        /// <summary>
        /// Get the logged in user's liked pages list async
        /// </summary>
        /// <returns>Liked pages list</returns>
        List<FacebookEntity> GetLikedPages();

        /// <summary>
        /// Delete a posted item aync.
        /// </summary>
        /// <param name="item">Item to delete</param>
        Task DeleteItemAsync(PostedItem item);

        /// <summary>
        /// Logout of facebbok
        /// </summary>
        void Logout();
    }
}
