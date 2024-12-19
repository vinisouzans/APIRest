using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class CarBusinessImplementation : ICarBusiness
    {
        private readonly IRepository<Car> _repository;

        private readonly CarConverter _converter;

        public CarBusinessImplementation(IRepository<Car> repository)
        {
            _repository = repository;
            _converter = new CarConverter();
        }

        //metodo responsavel por retornar tudo carro
        public List<CarVO> FindAll() 
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<CarVO> FindWithPagedSearch(
            string modelo, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from cars c where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(modelo)) query = query + $" and c.modelo like '%{modelo}%' ";
            query += $" order by c.modelo {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from cars c where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(modelo)) countQuery = countQuery + $" and c.modelo like '%{modelo}%' ";

            var cars = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<CarVO> {
                CurrentPage = page,
                List = _converter.Parse(cars),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        // Metodo responsavel por retornar um carro pelo ID
        public CarVO FindByID(long id) 
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Metodo responsavel por criar um novo carro
        public CarVO Create(CarVO car)
        {
            var carEntity = _converter.Parse(car);
            carEntity = _repository.Create(carEntity);
            return _converter.Parse(carEntity);
        }

        // Metodo responsavel por atualizar um carro 
        public CarVO Update(CarVO car)
        {
            var carEntity = _converter.Parse(car);
            carEntity = _repository.Update(carEntity);
            return _converter.Parse(carEntity);
        }

        // Method responsible for deleting a book from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
