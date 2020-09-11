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
           
            return Ok(postRepo.GetComment(id,cid));

        }
       /*
        [Route("{id}/comments")]
        [HttpPost]
        public IHttpActionResult CreateComment(Comment cm,int id)
        {
            
            postRepo.CreateComment(cm,id);
            string url = Url.Link("GetById", new { id = cm.CommentId });
            return Created(url,cm);
        }*/

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
        public IHttpActionResult EditComment( [FromUri] int id, [FromUri] int cid,[FromBody] Comment comment)
        {
            comment.CommentId = cid;
          
            postRepo.EditCommentByPostId(id,comment);

            return Ok();
        }

    }
}
