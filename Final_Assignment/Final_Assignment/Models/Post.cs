using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Column(TypeName = "varchar"), StringLength(40), Display(Name = "Post")]
        public string PostName { get; set; }

        public List<HyperLink> HyperLinks = new List<HyperLink>();
        public IEnumerable<Comment> Comments { get; set; }

    }
}