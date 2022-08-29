using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GulkortetNETFramework.Repositories
{
    // Ett generiskt repository som funkar för båda repositories TContext måste var av typ DbContext medans TEntity måste vara av typen class
    public abstract class GenericRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        // Properties i det här fallet en DbSet av typen TEntity t.ex. Kort, Kunder
        private readonly DbSet<TEntity> _db;


        // Ctor med DI på TContext
        protected GenericRepository(TContext context)
        {
            _db = context.Set<TEntity>();
        }


        // En metod som kollar om entiteten finns mot databasen bereoende på vad för expression man skickar in. Fungerar då både för Kund och Kort
        // Genom att skriva x => x.KortNr == string på kort och
        // x => x.KundNr == string för Kund
        public virtual async Task<bool> CheckValidity(Expression<Func<TEntity, bool>> predicate)
        {
            // En Try catch så programmet inte kraschar vid databas fel.
            try
            {
                // Skickar in mitt expression i AnyAsync Metoden och awaitar och returnar svaret
                return await _db.AnyAsync(predicate);
            }
            catch
            {
                // ignored
            }

            return false;
        }

        // En metod som kollar returnar en entitet från databasen bereoende på vad för expression man skickar in. Fungerar då både för Kund och Kort
        // Genom att skriva x => x.KortNr == string på kort och
        // x => x.KundNr == string för Kund
        public virtual async Task<TEntity> ReadEntity(Expression<Func<TEntity, bool>> predicate)
        {
            // En Try catch så programmet inte kraschar vid databas fel.
            try
            {
                // Skickar in mitt expression i AnyAsync Metoden och awaitar svaret tilldelar det till entity och kollar om det är null
                // returnar det om det inte är null.
                var entity = await _db.FirstOrDefaultAsync(predicate);
                if (entity != null)
                {
                    return entity;
                }
            }
            catch
            {
                // ignored
            }

            // Returnar null om något går fel eller om entitet inte finns
            return null;
        }

        // En metod som kollar returnar en IEnumerable av typ entitet från databasen bereoende på vad för expression man skickar in. Fungerar då både för Kund och Kort
        // Genom att skriva x => x.KortNr == string på kort och
        // x => x.KundNr == string för Kund
        public virtual async Task<IEnumerable<TEntity>> ReadEntities()
        {
            // En Try catch så programmet inte kraschar vid databas fel.
            try
            {
                // Returnar en IEnumerable av typen entitet
                return await _db.ToListAsync();
            }
            catch
            {
                // ignored
            }
            // Returnar null om något går fel eller om entitet inte finns
            return null;
        }
    }
}