using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assignment.Repository
{
    interface IPostRepository
    {
        Comment GetComment(int pid, int cid);
        void DeleteCommentByPostId(int id,int cid);

        void CreateComment(Comment entity);

        void EditCommentByPostId(Comment comment);
    }
}
