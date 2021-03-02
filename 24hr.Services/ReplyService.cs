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
                CreatedUtc = DateTimeOffset.Now,
                CommentId = model.CommentId
            };

            _context.Replies.Add(reply);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<ReplyListItem>> GetAllReplies()
        {
            List<Reply> replies = await _context.Replies.ToListAsync();
            List<ReplyListItem> replyListItems = replies
                .Where(reply => reply.Author == _userId)
                .Select(reply => new ReplyListItem()
                {
                    ReplyId = reply.ReplyId,
                    Author = _userId,
                    Text = reply.Text,
                    CreatedUtc = reply.CreatedUtc,
                    ModifiedUtc = reply.ModifiedUtc
                }).ToList();

            return replyListItems;
        }

        public async Task<ReplyDetail> GetReplyById(int id)
        {
            List<Reply> replies = await _context.Replies.ToListAsync();
            Reply replyToGet = replies.Single(reply => reply.ReplyId == id);
            ReplyDetail replyDetail = new ReplyDetail()
            {
                ReplyId = replyToGet.ReplyId,
                Author = replyToGet.Author,
                Text = replyToGet.Text,
                CreatedUtc = replyToGet.CreatedUtc,
                ModifiedUtc = replyToGet.ModifiedUtc,
                Comment = replyToGet.Comment
            };

            return replyDetail;
        }


                public async Task<List<ReplyListItem>> GetAllRepliesForComment(int commentId)
                {
                    List<Reply> replies = await _context.Replies.Where(
                        reply => reply.CommentId == commentId).ToListAsync();

        public async Task<List<ReplyListItem>> GetAllRepliesForComment(int commentId)
        {
            List<Reply> replies = await _context.Replies.Where(
                reply => reply.CommentId == commentId).ToListAsync();


               List<ReplyListItem> replyListItems = replies.Select(reply => new ReplyListItem()
               {
                        ReplyId = reply.ReplyId,
                        Author = _userId,
                        Text = reply.Text,
                        CreatedUtc = reply.CreatedUtc,
                        ModifiedUtc = reply.ModifiedUtc
               }).ToList();


                    return replyListItems;
                }

               return replyListItems;
        }


        public async Task<bool> EditReply(ReplyEdit model)
        {
            Reply replyToEdit = await _context.Replies.SingleAsync(reply => reply.ReplyId == model.ReplyId);
            replyToEdit.Text = model.Text;
            replyToEdit.ModifiedUtc = DateTimeOffset.Now;
            replyToEdit.CommentId = model.CommentId;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteReply(int id)
        {
            Reply replyToDelete = await _context.Replies.SingleAsync(reply => reply.ReplyId == id);
            _context.Replies.Remove(replyToDelete);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
