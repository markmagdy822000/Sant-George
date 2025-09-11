using System.Formats.Tar;
using System.Windows.Input;
using Sant_George.Models.PostModels;
using Sant_George.Repositories.Interfaces.Post;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Post
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
