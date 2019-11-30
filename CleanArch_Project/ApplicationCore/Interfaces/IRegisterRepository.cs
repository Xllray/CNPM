using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IRegisterRepository : IRepository<User>, IRepository<Customer>
    {

    }
}