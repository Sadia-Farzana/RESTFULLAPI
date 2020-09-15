using Assignment.Models;
using Final_Assignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Final_Assignment.Controllers
{
    [RoutePrefix("api/posts")]

    public class PostController : ApiController
    {
        PostRepository postRepo = new PostRepository();
        [Route("")]
        
        public IHttpActionResult Get()
        {
            return Ok(postRepo.GetAll());
        }


        [Route("{id}", Name = "GetById")]


        public IHttpActionResult Get(int id)
        {
            Post post = postRepo.GetById(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            //HATEOES Implementation
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId, HttpMethod = "GET", Relation = "Self" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts", HttpMethod = "POST", Relation = "Create a new Post resource" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId, HttpMethod = "PUT", Relation = "Edit a exsiting Post resource" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId, HttpMethod = "DELETE", Relation = "Delete a exsiting Post resource" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/"+post.PostId+"/comments" , HttpMethod = "GET", Relation = "Get all comments under this post" });



            return Ok(post);
        }
       
        [Route("{id}/comments")]
        public IHttpActionResult GetCommentsWithPost(int id)
        {
            
            return Ok(postRepo.GetCommentsWithPost(id));
        }

        [Route("{id}/comments/{cid}")]
        public IHttpActionResult GetComment(int id,int cid)
        {
            Comment com = postRepo.GetComment(id, cid);
            if (com == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments/" +com.CommentId , HttpMethod = "GET", Relation = "Self" });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments", HttpMethod = "POST", Relation = "Create a new Comment resource" });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments/" + com.CommentId, HttpMethod = "PUT", Relation = "Edit a exsiting Comment resource" });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments/" + com.CommentId, HttpMethod = "DELETE", Relation = "Delete a exsiting Comment resource" });
            
            return Ok(com);

        }
       
        [Route("{id}/comments"), HttpPost]
        
        public IHttpActionResult CreateComment(Comment com,int id)
        {
            
            com.PostId = id;
            postRepo.CreateComment(com);
            string url = Url.Link("GetById", new { id = com.PostId });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments/" + com.CommentId, HttpMethod = "GET", Relation = "Self" });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments", HttpMethod = "POST", Relation = "Create a new Comment resource" });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments/" + com.CommentId, HttpMethod = "PUT", Relation = "Edit a exsiting Comment resource" });
            com.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + com.PostId + "/comments/" + com.CommentId, HttpMethod = "DELETE", Relation = "Delete a exsiting Comment resource" });

            return Created(url,com);
        }

        [Route("")]
        public IHttpActionResult Post(Post post)
        {
            
            postRepo.Insert(post);
            string url = Url.Link("GetById", new { id = post.PostId });
            return Created(url, post);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody] Post post, [FromUri] int id)
        {
            post.PostId = id;
            postRepo.Edit(post);

            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId, HttpMethod = "GET", Relation = "Self" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts", HttpMethod = "POST", Relation = "Create a new Post resource" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId, HttpMethod = "PUT", Relation = "Edit a exsiting Post resource" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId, HttpMethod = "DELETE", Relation = "Delete a exsiting Post resource" });
            post.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + post.PostId + "/comments", HttpMethod = "GET", Relation = "Get all comments under this post" });

            return Ok(post);
        }


        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            postRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("{id}/comments/{cid}" , Name = "DeleteCommentByPostId")]
        public IHttpActionResult DeleteCommentByPostId(int id,int cid)
        {
            postRepo.DeleteCommentByPostId(id,cid);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/comments/{cid}" , Name = "EditCommentByPostId")]
        [HttpPut]
        public IHttpActionResult EditComment( [FromUri] int id, [FromUri] int cid,[FromBody] Comment comment)
        {
            comment.CommentId = cid;
            comment.PostId = id;
            postRepo.EditCommentByPostId(comment);
            comment.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + comment.PostId + "/comments/" + comment.CommentId, HttpMethod = "GET", Relation = "Self" });
            comment.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + comment.PostId + "/comments", HttpMethod = "POST", Relation = "Create a new Comment resource" });
            comment.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + comment.PostId + "/comments/" + comment.CommentId, HttpMethod = "PUT", Relation = "Edit a exsiting Comment resource" });
            comment.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44304/api/posts/" + comment.PostId + "/comments/" + comment.CommentId, HttpMethod = "DELETE", Relation = "Delete a exsiting Comment resource" });


            return Ok(comment);
        }

    }
}
