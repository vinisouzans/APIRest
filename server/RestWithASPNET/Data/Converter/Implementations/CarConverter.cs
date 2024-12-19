using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class CarConverter : IParser<CarVO, Car>, IParser<Car, CarVO>
    {
        public Car Parse(CarVO origin)
        {
            if (origin == null) return null;
            return new Car {
                Id = origin.Id,
                Modelo = origin.Modelo,
                FabDate = origin.FabDate,
                Preco = origin.Preco,
                Fabricante = origin.Fabricante
            };
        }

        public CarVO Parse(Car origin)
        {
            if (origin == null) return null;
            return new CarVO {
                Id = origin.Id,
                Modelo = origin.Modelo,
                FabDate = origin.FabDate,
                Preco = origin.Preco,
                Fabricante = origin.Fabricante
            };
        }

        public List<Car> Parse(List<CarVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CarVO> Parse(List<Car> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
