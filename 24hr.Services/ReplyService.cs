using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Services
{
    public class ReplyService
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateReply(ReplyCreate model)
        {
            Reply reply = new Reply()
            {
                Author = _userId,
                Text = model.Text,
                CreatedUtc = model.CreatedUtc
            };

            _context.Replies.Add(reply);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<ReplyListItem>> GetAllReplies()
        {
            List<Reply> replies = await _context.Replies.ToListAsync();
            List<ReplyListItem> replyListItems = replies.Select(reply => new ReplyListItem()
            {
                ReplyId = reply.ReplyId,
                Author = _userId,
                Text = reply.Text,
                CreatedUtc = reply.CreatedUtc
            }).ToList();

            return replyListItems;
        }


    }
}
