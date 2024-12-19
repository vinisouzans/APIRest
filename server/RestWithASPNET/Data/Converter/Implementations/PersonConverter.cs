using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new Person 
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Gender = origin.Gender,
                Cpf = origin.Cpf,
                DataNascimetno = origin.DataNascimento,
                Email = origin.Email,
                Celular = origin.Celular,
                Cidade = origin.Cidade,
                Uf = origin.Uf,
                Complemento = origin.Complemento,
                Bairro = origin.Bairro,
                Rua = origin.Rua,
                Numero = origin.Numero,
                Cep = origin.Cep,
                IdCartao = origin.IdCartao
            };           
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Gender = origin.Gender,
                Cpf = origin.Cpf,
                DataNascimento = origin.DataNascimetno,
                Email = origin.Email,
                Celular = origin.Celular,
                Cidade = origin.Cidade,
                Uf = origin.Uf,
                Complemento = origin.Complemento,
                Bairro = origin.Bairro,
                Rua = origin.Rua,
                Numero = origin.Numero,
                Cep = origin.Cep,
                IdCartao = origin.IdCartao
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
