using Sant_George.Models.Post;
using Sant_George.Repositories.Interfaces.Post;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Post
{
    public class PostRepository : GenericRepository<Sant_George.Models.Post.Post>, IPostRepository
    {
        public PostRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
