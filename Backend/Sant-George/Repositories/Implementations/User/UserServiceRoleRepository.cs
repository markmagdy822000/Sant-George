using Sant_George.Models.User;
using Sant_George.Repositories.Interfaces.User;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.User
{
    public class UserServiceRoleRepository : GenericRepository<UserServiceRole>, IUserServiceRoleRepository
    {
        public UserServiceRoleRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
