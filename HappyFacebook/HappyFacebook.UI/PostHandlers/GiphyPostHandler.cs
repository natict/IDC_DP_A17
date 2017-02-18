using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyFaceBook.BL;

namespace HappyFaceBook.UI.PostHandlers
{
    /// <summary>
    /// Handles posts with Giphy prefix
    /// </summary>
    public class GiphyPostHandler : PostHandlerBase
    {
        /// <summary>
        /// Use this prefix to randomly search for Gifs 
        /// </summary>
        public static string GiphyPrefix = @"\giphy";

        private IGiphyClient m_GiphyClient;
        private PictureBox m_PictureBoxPostSentPhoto;

        public GiphyPostHandler(IGiphyClient i_GiphyClient, PictureBox i_PictureBoxPostSentPhoto)
        {
            m_PictureBoxPostSentPhoto = i_PictureBoxPostSentPhoto;
            m_GiphyClient = i_GiphyClient;
        }

        protected override async Task<bool> HandleRequest(PostRequest request)
        {
            if (request.Message.ToLower().StartsWith(GiphyPrefix))
            {
                string searchFor = request.Message.Substring(GiphyPrefix.Length);
                string url = m_GiphyClient.Translate(searchFor);
                m_PictureBoxPostSentPhoto.Load(url);

                DialogResult res = MessageBox.Show("Do you want to post it?", "Interesting...", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    await FacebookApiClient.Instance.PostPictureURLAsync(url, searchFor);
                    request.RequestResult = "Gif Posted successfully!";
                }

                return false;
            }

            return true;
        }
    }
}
