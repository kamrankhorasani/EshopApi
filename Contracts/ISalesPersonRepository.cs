using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopApi.Models;

namespace EshopApi.Contracts
{
    public interface ISalesPersonRepository
    {
        IEnumerable<SalesPersons> GetAll();
        Task<SalesPersons> Add(SalesPersons salesPersons);
        Task<SalesPersons> Update(SalesPersons salesPersons);
        Task<SalesPersons> Find(int id);
        Task<SalesPersons> Remove(int id);
        Task<bool> IsExist(int id);
    }
}
