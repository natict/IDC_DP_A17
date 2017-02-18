using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFaceBook.UI.PostHandlers
{
    /// <summary>
    /// Represents a post request
    /// </summary>
    public class PostRequest
    {
        /// <summary>
        /// Textual message to post
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Picture to post URL
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Indicate wether Sentiment analysis should be performed
        /// </summary>
        public bool ShouldStayPositive { get; set; }

        /// <summary>
        /// Holds a textual result of the post processing
        /// </summary>
        public string RequestResult { get; set; }
    }
}
