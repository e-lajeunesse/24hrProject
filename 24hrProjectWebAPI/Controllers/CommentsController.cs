using _24hr.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24hrProjectWebAPI.Controllers
{
    [Authorize]
    public class CommentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            Comments commentType = CreateCommentType();
            var comment = commentType.GetComments();
            return Ok(comment);
        }

        public IHttpActionResult PostComment()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = CreateCommentPost();

            if (!post.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
    }
}