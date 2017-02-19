using HappyFaceBook.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyFacebook.UI.PostsFilter
{
    /// <summary>
    /// Abstract post filter
    /// </summary>
    public abstract class PostsFilterBase
    {
        /// <summary>
        /// Abstract method to be implemented by the concrete class. 
        /// Returns a decision predicate per detection based on the filter logic
        /// </summary>
        /// <returns></returns>
        protected abstract Func<IFacebookEntity, bool> GetPostFilterFunc();

        /// <summary>
        /// List of all posts.
        /// </summary>
        protected static List<IFacebookEntity> s_Posts;

        /// <summary>
        /// The binding source upon which we want to aply filter
        /// </summary>
        protected static BindingSource s_PostsBindingSource;

        public static void SetPosts(List<IFacebookEntity> i_Posts, BindingSource i_PostsBindingSource)
        {
            s_Posts = i_Posts;
            s_PostsBindingSource = i_PostsBindingSource;
        }

        /// <summary>
        /// Factory method, returns the concrete filter
        /// </summary>
        /// <param name="i_FilterType">Filter type to be used</param>
        /// <returns>A concrete filter object</returns>
        public static PostsFilterBase GetPostsFilter(ePostsFilterType i_FilterType)
        {
            switch (i_FilterType)
            {
                case ePostsFilterType.MostRecent:
                    return new RecentPostsFilter();
                case ePostsFilterType.WithLikes:
                    return new PostsWithLikesFilter();
                case ePostsFilterType.WithComments:
                    return new PostsWithCommentsFilter();
                case ePostsFilterType.All:
                default:
                    return new PostsWithNoFilter();
            }
        }

        /// <summary>
        /// Perform the actual filter, using concrete (using the concrete filter)
        /// </summary>
        public void FilterPosts()
        {
            if (s_Posts != null)
            {
                var filteredItems = s_Posts.Where(GetPostFilterFunc());
                if (filteredItems.Any())
                {
                    s_PostsBindingSource.DataSource = filteredItems;
                }
                else
                {
                    s_PostsBindingSource.DataSource = new List<IFacebookEntity>();
                }
            }
        }
    }
}
