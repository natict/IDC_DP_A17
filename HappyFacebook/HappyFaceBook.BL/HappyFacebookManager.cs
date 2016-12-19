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
    public class HappyFacebookManager
    {
        /// <summary>
        /// Current logged in user.
        /// </summary>
        private User m_LoggedInUser;

        /// <summary>
        /// 
        /// </summary>
        private static HappyFacebookManager s_Instance;

        /// <summary>
        /// An object to
        /// </summary>
        private static object s_LockContext = new object();

        private HappyFacebookManager()
        {
            FacebookService.s_UseForamttedToStrings = true;
            FacebookService.s_CollectionLimit = 100;
            FacebookService.s_FbApiVersion = 2.8f;
        }

        /// <summary>
        /// Singleton Instance of the manager
        /// </summary>
        public static HappyFacebookManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockContext)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new HappyFacebookManager();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public void LoginAndInit()
        {
           LoginResult result = FacebookService.Login("120866478407900", /// (desig patter's)
                "public_profile",
                "user_education_history",
                "user_birthday",
                "user_actions.video",
                "user_actions.news",
                "user_actions.music",
                "user_actions.fitness",
                "user_actions.books",
                "user_about_me",
                "user_friends",
                "publish_actions",
                "user_events",
                "user_games_activity",
                //"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
                "user_hometown",
                "user_likes",
                "user_location",
                "user_managed_groups",
                "user_photos",
                "user_posts",
                "user_relationships",
                "user_relationship_details",
                "user_religion_politics",

                //"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
                "user_tagged_places",
                "user_videos",
                "user_website",
                "user_work_history",
                "read_custom_friendlists",

                // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
                "read_page_mailboxes",
                // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
                // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
                "manage_pages",
                "publish_pages",
                "publish_actions",

                "rsvp_event"
                );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
            else
            {
                throw new FacebookLoginException();
            }
        }

        public async Task<string> GetLoggedInUserPictureUrlAsync()
        {
            return await Task.Run(() => m_LoggedInUser.PictureNormalURL);
        }

        public async Task<string> GetLoggedInUserNameAsync()
        {
            return await Task.Run(() => m_LoggedInUser.Name);
        }

        public async Task<List<string>> GetUserPostMessagesAsync()
        {
            return await Task.Run(() => m_LoggedInUser.Posts.Select(post => post.Message).ToList());
        }

        public async Task<List<FacebookEntity>> GetUserPostsAsync()
        {
            List<FacebookEntity> postsList = new List<FacebookEntity>();

            FacebookObjectCollection<Post> posts = null;
            await Task.Run(() => posts = m_LoggedInUser.Posts);

            foreach (Post post in posts)
            {
                string message = string.Empty;
                if (post.Message != null)
                {
                    message = post.Message;
                }
                else if (post.Caption != null)
                {
                    message = post.Caption;
                }
                else
                {
                    message = $"[{post.Type}]";
                }

                string pictureUrl = string.Empty;
                if (post.PictureURL != null && !post.PictureURL.Contains(@"/safe_image"))
                {
                    pictureUrl = post.PictureURL;

                }
                else
                {
                    pictureUrl = post.Link;
                }

                postsList.Add(new FacebookEntity
                {
                    Name = message,
                    PictureUrl = pictureUrl,
                    Item = post
                });
            }

            return postsList;
        }

        /// <summary>
        /// Posts a status async
        /// </summary>
        /// <param name="i_Url">Picture to post url</param>
        /// <param name="i_Caption">PiPicture to post textparam>
        /// <returns></returns>
        public async Task PostStatusAsync(string i_StatusText, string i_PictureTitle = null)
        {
            await Task.Run(() =>
            {
                m_LoggedInUser.PostStatus(i_StatusText, i_PictureURL: i_PictureTitle);
                m_LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.Full);
            });
        }

        /// <summary>
        /// Posts a picture URL async, and refreshes the posts list
        /// </summary>
        /// <param name="i_Url">Picture to post url</param>
        /// <param name="i_Caption">PiPicture to post textparam>
        public async Task PostPictureURLAsync(string i_Url, string i_Caption)
        {
            await Task.Run(() =>
            {
                m_LoggedInUser.PostLink(i_Url, i_Caption);
                m_LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.Full);
            });
        }

        /// <summary>
        /// Posts a picture async, and refreshes the posts list
        /// </summary>
        /// <param name="i_PicturePath">Picture to post path</param>
        /// <param name="i_PictureTitle">Picture to post text</param>
        public async Task PostPictureAsync(string i_PicturePath, string i_PictureTitle)
        {
            await Task.Run(() =>
            {
                m_LoggedInUser.PostPhoto(i_PicturePath, i_PictureTitle, i_PictureTitle);
                m_LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.Full);
            });
        }

        public async Task<List<FacebookEntity>> GetFriendsAsync()
        {
            List<FacebookEntity> friends = new List<FacebookEntity>();
            await Task.Run(() =>
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    //friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                    friends.Add(new FacebookEntity() {Name = friend.Name, PictureUrl = friend.PictureNormalURL});
                }
            });

            return friends;
        }

        public async Task<List<FacebookEntity>> GetEventsAsync()
        {
            List<FacebookEntity> events = new List<FacebookEntity>();
            await Task.Run(() =>
            {
                foreach (Event evnt in m_LoggedInUser.Events)
                {
                    events.Add(new FacebookEntity() { Name = $"{evnt.StartTime}     {evnt.Owner}        {evnt.Location}     {evnt.Name}", PictureUrl = evnt.PictureNormalURL });
                }
            });

            return events;
        }

        public List<FacebookEntity> GetCheckins()
        {
            List<FacebookEntity> checkins = new List<FacebookEntity>();
            foreach (Checkin checkin in m_LoggedInUser.Checkins)
            {
                checkins.Add(new FacebookEntity() { Name = checkin.Place.Name });
            }

            return checkins;
        }

        public List<FacebookEntity> GetLikedPages()
        {
            List<FacebookEntity> pages = new List<FacebookEntity>();
            foreach (Page page in m_LoggedInUser.LikedPages)
            {
                pages.Add(new FacebookEntity() { Name = page.Name});
            }

            return pages;
        }

        public async Task DeleteItemAsync(PostedItem item)
        {
            await Task.Run(() =>
            {
                item.Delete();
                m_LoggedInUser.ReFetch();
            });
        }

        public void Logout()
        {
            FacebookService.Logout(() => { });
        }
    }
}
