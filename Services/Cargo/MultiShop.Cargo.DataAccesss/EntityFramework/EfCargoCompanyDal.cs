using MultiShop.Cargo.DataAccesss.Abstract;
using MultiShop.Cargo.DataAccesss.Concrete;
using MultiShop.Cargo.DataAccesss.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccesss.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {
        }
    }
}
