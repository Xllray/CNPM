using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductContext _context;

        public UnitOfWork(ProductContext context)
        {
            Products = new ProductRepository(context);
            //Customers = new CustomerRepository(context);


            //khai bao user reponsitory
            //....
            //...

            _context = context;
        }

       

        public IProductRepository Products { get; private set; }

        public IRegisterRepository Registers { get; private set; }

        // public ICustomerRepository Customers { get; private set; }

        //khai bao interface Reponsitory

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}