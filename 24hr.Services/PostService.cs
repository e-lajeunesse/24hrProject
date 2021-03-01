using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Text = model.Text,
                    CreatedPost = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(p => p.OwnerId == _userId)
                        .Select(
                            p=>
                                new PostListItem
                                {
                                    PostId = p.PostId,
                                    Title = p.Title,
                                    CreatedPost = p.CreatedPost
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
