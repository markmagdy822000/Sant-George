using Sant_George_Website.Repositories.Interfaces;
using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Implementations;

namespace Sant_George_Website.Repositories.Implementations
{
    public class UserParentRepository : GenericRepository<UserParent>, IUserParentRepository
    {
        public UserParentRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
