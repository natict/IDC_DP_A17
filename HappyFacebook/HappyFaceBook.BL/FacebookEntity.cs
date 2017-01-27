using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace HappyFaceBook.BL
{
    public class FacebookEntity : IFacebookEntity
    {
        public DateTime? CreatedTime { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public string From { get; set; }

        public string Name { get; set; }

        public string PictureUrl { get; set; }

        [System.ComponentModel.Browsable(false)]
        public PostedItem Item
        {
            get { return _item; }
            set
            {
                Task.Run(() =>
                {
                    _item = value;
                    Likes = _item.LikedBy.Count;
                    Comments = _item.Comments.Count;
                    CreatedTime = _item.CreatedTime;
                    From = _item.From?.Name;
                });
            }
        }

        private PostedItem _item;
    }
}
