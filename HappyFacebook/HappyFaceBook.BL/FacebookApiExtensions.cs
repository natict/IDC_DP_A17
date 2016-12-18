using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace HappyFaceBook.BL
{
    public static class FacebookApiExtensions
    {
        public static string GetUserId(this User user)
        {
            return $"{user.Id}_{user.Name}";
        }

        public static string GetUserName(this string userId)
        {
            return userId.Split('_')[1];
        }
    }
}
