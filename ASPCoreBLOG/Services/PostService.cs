using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreBLOG.Models;

namespace ASPCoreBLOG.Services
{
    public class PostService : IPostService
    {
        List<Post> posts;
        public PostService()
        {
            posts = new List<Post>
            {
                new Post{Id = 1,Content = "Post1 - content",Title="Post1",Comments = new List<Comment>{ new Comment { Id=1, Content="Comment1",PostId = 1} } },
                new Post{Id = 2,Content = "Post2 - content",Title="Post2"},
                new Post{Id = 3,Content = "Post3 - content",Title="Post3"},
                new Post{Id = 4,Content = "Post4 - content",Title="Post4"}
            };
        }
        public Post Add(Post newPost)
        {
            if (newPost != null) posts.Add(newPost);
            
            return newPost;
        }

        public Post AddComment(int postId,Comment comment)
        {
            posts.FirstOrDefault(x => x.Id == postId).Comments.Add(comment);
            return posts.FirstOrDefault(x => x.Id == postId);
        }

        public List<Post> All()
        {
            return posts;
        }

        public Post Detail(int id)
        {
            return posts.FirstOrDefault(x => x.Id == id);
        }

        public Post Edit(Post EditedPost)
        {
            posts.FirstOrDefault(x => x.Id == EditedPost.Id).Title = EditedPost.Title;
            posts.FirstOrDefault(x => x.Id == EditedPost.Id).Content = EditedPost.Content;
            posts.FirstOrDefault(x => x.Id == EditedPost.Id).Time = EditedPost.Time;
            var post = posts.FirstOrDefault(x => x.Id == EditedPost.Id);
            return post;
        }
    }
}
