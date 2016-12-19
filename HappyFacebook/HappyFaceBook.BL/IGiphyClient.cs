using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFaceBook.BL
{
    public interface IGiphyClient
    {
        string Translate(string i_Text);
    }
}
