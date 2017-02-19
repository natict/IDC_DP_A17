using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFacebook.UI.PostsFilter
{
    /// <summary>
    /// Supported types of post filtering
    /// </summary>
    public enum ePostsFilterType
    {
        All,
        WithLikes,
        WithComments,
        MostRecent
    }
}
