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
        /// <summary>
        /// time when the entity was created
        /// </summary>
        DateTime? CreatedTime { get; set; }

        /// <summary>
        /// Total amount of likes the entity received
        /// </summary>
        int Likes { get; set; }

        /// <summary>
        /// Total amount of comments the entity received
        /// </summary>
        int Comments { get; set; }

        /// <summary>
        /// Name of who user which created this entity
        /// </summary>
        string From { get; set; }

        /// <summary>
        /// Name of the entity
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Picture of the entity
        /// </summary>
        string PictureUrl { get; set; }

        PostedItem Item { get; set; }
    }
}