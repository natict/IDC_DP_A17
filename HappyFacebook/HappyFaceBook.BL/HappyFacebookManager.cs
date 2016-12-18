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
        private User m_LoggedInUser;

        private static HappyFacebookManager s_Instance;

        private static object lockContext = new object();

        public HappyFacebookManager()
        {
            FacebookService.s_UseForamttedToStrings = true;
            FacebookService.s_CollectionLimit = 100;
            FacebookService.s_FbApiVersion = 2.8f;
        }

        public static HappyFacebookManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (lockContext)
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
            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
           LoginResult result = FacebookService.Login("120866478407900", /// (desig patter's "Design Patterns Course App 2.4" app)
           //LoginResult result = FacebookService.Login("1908224946078795", // Y
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

        public string GetLoggedInUserPictureUrl()
        {
            return m_LoggedInUser.PictureNormalURL;
        }

        public List<string> GetUserPostMessages()
        {
            return m_LoggedInUser.Posts.Select(post => post.Message).ToList();
        }

        public async Task<List<FacebookEntity>> GetUserPosts()
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

                postsList.Add(new FacebookEntity
                {
                    Name = message,
                    PictureUrl = post.PictureURL,
                    Item = post
                });
            }

            return postsList;
        }

        public async Task PostStatus(string i_StatusText, string i_PictureTitle = null)
        {
            await Task.Run(() =>
            {
                m_LoggedInUser.PostStatus(i_StatusText, i_PictureURL: i_PictureTitle);
                m_LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.Full);
            });
        }

        public void PostPictureURL(string i_Url)
        {
            m_LoggedInUser.PostLink(i_Url, "");
        }

        public async Task PostPicture(string i_PicturePath, string i_PictureTitle)
        {
            //`var webClient = new WebClient();
            //byte[] imageBytes = webClient.DownloadData(i_PicturePath);

            await Task.Run(() =>
            {
                m_LoggedInUser.PostPhoto(i_PicturePath, i_PictureTitle, i_PictureTitle);
                m_LoggedInUser.ReFetch(DynamicWrapper.eLoadOptions.Full);
            });
        }

        public List<FacebookEntity> GetFriends()
        {
            List<FacebookEntity> friends = new List<FacebookEntity>();
            foreach (User friend in m_LoggedInUser.Friends)
            {
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                friends.Add(new FacebookEntity() {Name = friend.Name, PictureUrl = friend.PictureNormalURL});
            }

            return friends;
        }

        public List<FacebookEntity> GetEvents()
        {
            List<FacebookEntity> events = new List<FacebookEntity>();
            foreach (Event evnt in m_LoggedInUser.Events)
            {
                events.Add(new FacebookEntity() { Name = evnt.Name, PictureUrl = evnt.PictureNormalURL});
            }

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

        public List<FacebookEntity> GetLikedPagesPages()
        {
            List<FacebookEntity> pages = new List<FacebookEntity>();
            foreach (Page page in m_LoggedInUser.LikedPages)
            {
                pages.Add(new FacebookEntity() { Name = page.Name});
            }

            return pages;
        }

        public async Task DeleteItem(PostedItem item)
        {
            await Task.Run(() =>
            {
                item.Delete();
                m_LoggedInUser.ReFetch();
            });
        }
    }
}
