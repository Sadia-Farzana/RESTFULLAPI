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
            /*cat.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44334/api/categories/" + cat.CategoryId, HttpMethod = "GET", Relation = "Self" });
            cat.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44334/api/categories", HttpMethod = "POST", Relation = "Create a new Category resource" });
            cat.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44334/api/categories/" + cat.CategoryId, HttpMethod = "PUT", Relation = "Edit a exsiting Category resource" });
            cat.HyperLinks.Add(new HyperLink() { HRef = "https://localhost:44334/api/categories/" + cat.CategoryId, HttpMethod = "DELETE", Relation = "Delete a exsiting Category resource" });*/


            return Ok(post);
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
           
            return Ok(post);
        }


        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            postRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
