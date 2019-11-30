using System;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        IProductRepository Products { get; }
      
        IRegisterRepository Registers{ get; }
        int Complete();
    }
}