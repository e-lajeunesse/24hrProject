using _24hr.Data;
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
            var entity = new Comments()
            {
                Id = _userId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public 

    }
}
