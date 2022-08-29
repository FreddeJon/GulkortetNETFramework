using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GulkortetNETFramework.Models;

namespace GulkortetNETFramework.Repositories.Interfaces
{
    // Ett interface för att kunna göra DI sami IOC
    public interface ICardRepository
    {
        Task<bool> CheckValidity(Expression<Func<Kort, bool>> predicate);
        Task<Kort> ReadEntity(Expression<Func<Kort, bool>> predicate);
        Task<IEnumerable<Kort>> ReadEntities();
    }
}
