﻿using Assignment.Models;
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

    }
}