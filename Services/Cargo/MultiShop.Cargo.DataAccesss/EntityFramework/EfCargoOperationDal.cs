using MultiShop.Cargo.DataAccesss.Abstract;
using MultiShop.Cargo.DataAccesss.Concrete;
using MultiShop.Cargo.DataAccesss.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccesss.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
