using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class PhonenumberRepository : GenericRepository<Phonenumber>, IPhonenumberRepository
    {
        public PhonenumberRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
