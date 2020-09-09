using Assignment.Models;
using InventoryCodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Assignment.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public List<Comment> GetCommentsWithPost(int id)
        {
            return this.context.Comments.Where(x => x.PostId == id).ToList();
        }

       /* public void CreateComment(Comment entity,int id)
        {
            context.Comments.Where(x => x.PostId == id);
            context.Comments.Add(entity); 
            context.SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            context.Set<Comment>().Where(x => x.PostId == id);
            return context.Set<Comment>().Find(id);
        }

        /*
      
        
           public void Delete(int id)
        {
            context.Set<T>().Remove(GetById(id));
            context.SaveChanges();
        }
        */

    }
}