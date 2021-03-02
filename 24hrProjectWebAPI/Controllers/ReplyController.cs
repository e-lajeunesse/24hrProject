using _24hr.Models;
using _24hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _24hrProjectWebAPI.Controllers
{
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            ReplyService replyService = new ReplyService(userId);
            return replyService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateReply(ReplyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReplyService service = CreateReplyService();
            if (!await service.CreateReply(model))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllReplies()
        {
            ReplyService service = CreateReplyService();
            List<ReplyListItem> replies = await service.GetAllReplies();
            return Ok(replies);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetReplyById(int id)
        {
            ReplyService service = CreateReplyService();
            ReplyDetail reply = await service.GetReplyById(id);
            return Ok(reply);
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditReply(ReplyEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReplyService service = CreateReplyService();
            if (!await service.EditReply(model))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]

        public async Task<IHttpActionResult> DeleteReply(int id)
        {
            ReplyService service = CreateReplyService();
            if (!await service.DeleteReply(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
