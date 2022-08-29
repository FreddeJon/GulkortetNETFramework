using GulkortetNETFramework.Models;
using GulkortetNETFramework.Repositories.Interfaces;

namespace GulkortetNETFramework.Repositories
{
    // Ett CardRepository som ärver från GenericRepository där den kastar säger att TContext = UserContext och TEntity är Kunder
    public class UserRepository : GenericRepository<UserContext, Kunder>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
            
        }
    } 
}
