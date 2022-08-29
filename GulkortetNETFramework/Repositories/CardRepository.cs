
using GulkortetNETFramework.Models;
using GulkortetNETFramework.Repositories.Interfaces;

namespace GulkortetNETFramework.Repositories
{
    // Ett CardRepository som ärver från GenericRepository där den kastar säger att TContext = CardContext och TEntity är Kort
    public class CardRepository : GenericRepository<CardContext, Kort>, ICardRepository
    {

        // CTOR Tar in CardContext via di och skickar det till GenericRepository
        public CardRepository(CardContext context) : base(context)
        {

        }
    }
}
