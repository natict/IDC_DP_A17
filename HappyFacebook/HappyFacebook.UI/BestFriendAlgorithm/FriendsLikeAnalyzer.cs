using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyFacebook.UI.BestFriendAlgorithm
{
    class FriendsLikeAnalyzer: FriendsActivityAnalyzer
    {
        protected override int GetCommentScore()
        {
            return 2;
        }

        protected override int GetLikeScore()
        {
            return 4;
        }

        protected override int GetCommentForCommentScore()
        {
            return 1;
        }

        protected override int GetLikeForCommentScore()
        {
            return 3;
        }

        protected override int SortItems(KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
        {
            return pair1.Key.CompareTo(pair2.Key);
        }
    }
}
