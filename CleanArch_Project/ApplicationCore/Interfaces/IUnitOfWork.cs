using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        IProductRepository Products { get; }
      
       

        IUserRepository Users { get; }
        int Complete();
    }
}