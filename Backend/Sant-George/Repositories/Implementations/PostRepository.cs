using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
