using HappyFaceBook.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFacebook.UI.PostsFilter
{
    /// <summary>
    /// Filter which returns all posts of last 2 weeks.
    /// </summary>
    class RecentPostsFilter : PostsFilterBase
    {
        protected override Func<IFacebookEntity, bool> GetPostFilterFunc()
        {
            return entity => entity.CreatedTime > DateTime.UtcNow.AddDays(-14) ;
        }
    }
}
