using _24hr.Data;
using _24hr.Models;
using _24hr.Services;
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
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        public IHttpActionResult Get()
        {
            var commentService = CreateCommentService();
            var comment = commentService.GetComments();
            return Ok(comment);
        }

        public IHttpActionResult PostComment(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = CreateCommentService();

            if (!post.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
    }
}