using System.Formats.Tar;
using System.Windows.Input;
using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
