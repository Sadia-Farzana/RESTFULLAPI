using Assignment.Models;
using InventoryCodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Final_Assignment.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public List<Comment> GetCommentsWithPost(int id)
        {
            return this.context.Comments.Where(x => x.PostId == id).ToList();
        }
        
        public void CreateComment(Comment entity,int id)
        {
            
            var check = context.Comments.Single(x => x.PostId == id);
            context.Comments.Add(entity);
            context.SaveChanges();
        }
        
       /* public Comment GetCommentById(int id,int cid)
        {
            //*var test = context.Comments.Where(x => x.PostId == id).Select(y => y.CommentId);
            /*if (test != null)
            {
                return context.Set<Comment>().Find(id);
            }
            return context.Comments.Find(test);

            return context.Comments.SingleOrDefault(c => c.PostId == id && c.CommentId == cid);
        }*/

        public void DeleteCommentByPostId(int id,int cid)
        {
            var delete = context.Comments.Single(x => x.PostId == id && x.CommentId == cid);
            context.Comments.Remove(delete);
            context.SaveChanges();
        }

        public void EditCommentByPostId(int id,Comment entity)
        {
            var edit = context.Comments.Single(x => x.PostId == id);
            if (edit != null)
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /*
        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        } */
        public Comment GetComment(int pid, int cid)
        {
            return context.Comments.SingleOrDefault(c => c.PostId == pid && c.CommentId == cid);
        }




    }
}