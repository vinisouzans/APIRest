using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ICarBusiness
    {
        CarVO Create(CarVO car);
        CarVO FindByID(long id);
        List<CarVO> FindAll();
        PagedSearchVO<CarVO> FindWithPagedSearch(
            string modelo, string sortDirection, int pageSize, int page);
        CarVO Update(CarVO car);
        void Delete(long id);
    }
}
