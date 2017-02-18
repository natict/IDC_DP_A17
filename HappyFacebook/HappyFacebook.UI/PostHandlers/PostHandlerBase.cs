using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFaceBook.UI.PostHandlers
{
    public abstract class PostHandlerBase
    {
        protected PostHandlerBase m_Successor;

        protected abstract Task<bool> HandleRequest(PostRequest request);

        public void SetSuccessor(PostHandlerBase successor)
        {
            m_Successor = successor;
        }

        public async Task ProcessRequest(PostRequest request)
        {
            bool shouldContinue = await HandleRequest(request);

            if (shouldContinue && m_Successor != null)
            {
                await m_Successor.ProcessRequest(request);
            }
        }
    }
}
