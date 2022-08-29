using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GulkortetNETFramework.Models;

namespace GulkortetNETFramework.Repositories.Interfaces
{
    // Ett interface för att kunna göra DI sami IOC
    public interface IUserRepository
    {
        Task<bool> CheckValidity(Expression<Func<Kunder, bool>> predicate);
        Task<Kunder> ReadEntity(Expression<Func<Kunder, bool>> predicate);
        Task<IEnumerable<Kunder>> ReadEntities();
    }
}