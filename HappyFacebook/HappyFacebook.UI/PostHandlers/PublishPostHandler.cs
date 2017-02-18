using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyFaceBook.BL;

namespace HappyFaceBook.UI.PostHandlers
{
    /// <summary>
    /// A regular post (textual\picture) handler.
    /// </summary>
    public class PublishPostHandler : PostHandlerBase
    {
        protected override async Task<bool> HandleRequest(PostRequest request)
        {
            if (request.PictureUrl != string.Empty)
            {
                await FacebookApiClient.Instance.PostPictureAsync(request.PictureUrl, request.Message);
                request.RequestResult = "Picture Posted successfully!";
            }
            else
            {
                await FacebookApiClient.Instance.PostStatusAsync(request.Message);
                request.RequestResult = "Message Posted successfully!";
            }

            return true;
        }
    }
}
