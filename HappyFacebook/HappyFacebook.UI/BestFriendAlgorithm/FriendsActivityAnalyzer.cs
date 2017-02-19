using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using HappyFaceBook.BL;

namespace HappyFacebook.UI.BestFriendAlgorithm
{
    abstract class FriendsActivityAnalyzer
    {
        protected abstract int GetCommentScore();
        protected abstract int GetLikeScore();
        protected abstract int GetCommentForCommentScore();
        protected abstract int GetLikeForCommentScore();

        protected abstract int SortItems(KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2);

        public async Task<List<KeyValuePair<string, int>>> Analayze(List<IFacebookEntity> i_Posts)
        {
            ConcurrentDictionary<string, int> likesDictionary = new ConcurrentDictionary<string, int>();
            await Task.Run(() =>
            {
                // for all posts
                Parallel.ForEach(
                    i_Posts,
                    (post) =>
                    {
                        // All likes on post
                        Parallel.ForEach(post.Item.LikedBy, (like) => { updateImpactScore(like, likesDictionary, GetLikeScore()); });

                        // All comments in post
                        Parallel.ForEach(
                            post.Item.Comments,
                            (comment) =>
                            {
                                updateImpactScore(comment.From, likesDictionary, GetCommentScore());

                                // All likes for comment
                                Parallel.ForEach(comment.LikedBy, (commentLike) => { updateImpactScore(commentLike, likesDictionary, GetLikeForCommentScore()); });

                                // All comments for comment
                                Parallel.ForEach(
                                    comment.Comments,
                                    (innerComment) =>
                                    {
                                        updateImpactScore(innerComment.From, likesDictionary, GetCommentForCommentScore());

                                        // All likes for comment in comment
                                        foreach (var innerCommentLike in innerComment.LikedBy)
                                        {
                                            updateImpactScore(innerCommentLike, likesDictionary, GetCommentForCommentScore());
                                        }
                                    });
                            });
                    });
            });

            // Sort and set to data grid.
            List<KeyValuePair<string, int>> friendsActivityList = likesDictionary.Select(kv => new KeyValuePair<string, int>(kv.Key.GetUserName(), kv.Value)).ToList();
            friendsActivityList.Sort(SortItems);

            return friendsActivityList;
        }

        /// <summary>
        /// Thread safe update of friend activity count on my wall.
        /// </summary>
        /// <param name="i_User">The user which performed an activity on my wall</param>
        /// <param name="i_FriendsActivityDictionary">Dictionary which contains the activity count of my friend on my wall</param>
        /// <param name="i_ScoreAddition">Amount of points to add to score</param>
        private void updateImpactScore(User i_User, ConcurrentDictionary<string, int> i_FriendsActivityDictionary, int i_ScoreAddition)
        {
            var userId = i_User.GetUserId();

            if (!i_FriendsActivityDictionary.ContainsKey(userId))
            {
                lock (i_FriendsActivityDictionary)
                {
                    if (!i_FriendsActivityDictionary.ContainsKey(userId))
                    {
                        i_FriendsActivityDictionary[userId] = 0;
                    }
                }
            }

            i_FriendsActivityDictionary[userId] += i_ScoreAddition;
        }
    }
}
