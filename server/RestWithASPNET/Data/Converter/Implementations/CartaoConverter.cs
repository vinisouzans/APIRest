using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class CartaoConverter : IParser<CartaoVO, Cartao>, IParser<Cartao, CartaoVO>
    {
        public Cartao Parse(CartaoVO origin) 
        {
            if (origin == null) return null;
            return new Cartao 
            {
                Id = origin.Id,
                Numero = origin.Numero,
                Validade = origin.Validade,
                Nome = origin.Nome,
                Cpf = origin.Cpf,
                Bandeira = origin.Bandeira,
                Credito = origin.Credito,
                IdPerson = origin.IdPerson,
                Ativo = origin.Ativo,
                Cvv = origin.Cvv,
            };
        } 

        public CartaoVO Parse(Cartao origin)
        {
            if (origin == null) return null;
            return new CartaoVO 
            {
                Id = origin.Id,
                Numero = origin.Numero,
                Validade = origin.Validade,
                Nome = origin.Nome,
                Cpf = origin.Cpf,
                Bandeira = origin.Bandeira,
                Credito = origin.Credito,
                IdPerson = origin.IdPerson,
                Ativo = origin.Ativo,
                Cvv = origin.Cvv,
            };
        }

        public List<Cartao> Parse(List<CartaoVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CartaoVO> Parse(List<Cartao> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
