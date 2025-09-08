using Sant_George_Website.Repositories.Interfaces;
using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Implementations;

namespace Sant_George_Website.Repositories.Implementations
{
    public class UserServiceRoleRepository : GenericRepository<UserServiceRole>, IUserServiceRoleRepository
    {
        public UserServiceRoleRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
