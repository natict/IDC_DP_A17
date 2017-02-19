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
    /// Filter which returns only posts with comments
    /// </summary>
    public class PostsWithCommentsFilter : PostsFilterBase
    {
        protected override Func<IFacebookEntity, bool> GetPostFilterFunc()
        {
            return entity => entity.Comments> 0;
        }
    }
}
