using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Column(TypeName = "varchar"), StringLength(40), Display(Name = "Comment")]
        public string CommentName { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}