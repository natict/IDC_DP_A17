using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace HappyFaceBook.BL
{
    public interface IFacebookEntity
    {
        DateTime? CreatedTime { get; set; }

        int Likes { get; set; }

        int Comments { get; set; }

        string From { get; set; }

        string Name { get; set; }

        string PictureUrl { get; set; }

        PostedItem Item { get; set; }
    }
}
