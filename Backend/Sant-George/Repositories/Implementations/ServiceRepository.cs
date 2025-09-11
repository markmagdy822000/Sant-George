using Sant_George.Models;
using Sant_George.Models;
using Sant_George.Repositories.Interfaces;

namespace Sant_George.Repositories.Implementations
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
