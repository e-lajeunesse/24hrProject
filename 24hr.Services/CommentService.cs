using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Text = model.Text,
                PostId = model.PostId,
                Author = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<CommentListItems> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments.Where(a => a.Author == _userId).Select
                    (a => new CommentListItems
                    {
                        Id = a.Id,
                        Author = a.Author,
                        Text = a.Text,
                        PostId = a.PostId,
                        Reply = a.Reply
                    }); 
                return query.ToList();
            }
        }
    }
}
