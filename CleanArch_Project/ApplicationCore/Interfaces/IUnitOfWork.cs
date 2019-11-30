using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        IProductRepository Products { get; }
      
       // ICustomerRepository Customers { get; }
        int Complete();
    }
}