using Assignment.Models;
using InventoryCodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Assignment.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public List<Comment> GetCommentsWithPosts()
        {
           
            return this.context.Comments.Include("Post").ToList();
        }



        public Comment GetCommentWithPost(int id)
        {
            return this.context.Comments.Include("Post")
                                          .Where(x => x.CommentId== id)
                                          .FirstOrDefault();
        }


    }

}