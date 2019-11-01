using ASPCoreBLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreBLOG.Services
{
    public interface IPostService
    {
        List<Post >All();

        Post Detail(int id);

        Post Add(Post newPost);
        Post AddComment(int postId,Comment comment);
        Post Edit(Post EditedPost);
    }
}
