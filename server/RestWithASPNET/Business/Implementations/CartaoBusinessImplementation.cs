using Microsoft.EntityFrameworkCore.Query;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class CartaoBusinessImplementation : ICartaoBusiness
    {
        private readonly IRepository<Cartao> _repository;

        private readonly CartaoConverter _converter;

        public CartaoBusinessImplementation(IRepository<Cartao> repository)
        {
            _repository = repository;
            _converter = new CartaoConverter();
        }

        // Method responsible for returning all people,
        public List<CartaoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<CartaoVO> FindWithPagedSearch(
            string nome, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from tb_cartao c where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(nome)) query = query + $" and c.NOME like '%{nome}%' ";
            query += $" order by c.NOME {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from tb_cartao c where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(nome)) countQuery = countQuery + $" and c.NOME like '%{nome}%' ";

            var cartoes = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<CartaoVO> {
                CurrentPage = page,
                List = _converter.Parse(cartoes),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public string BuscaIdCartaoPorIdPerson(string idPerson)
        {
            string query = "";
            //essa query tenta selecionar o id do cartão a partir do id da pessoa, caso não encontre a clausula union devolve zero
            if (!string.IsNullOrWhiteSpace(idPerson.ToString())) {
                query = $"SELECT ID FROM tb_cartao c WHERE c.ID_PERSON = {idPerson} AND c.ATIVO = 1";
                query += $" UNION";
                query += $" SELECT 0 as ID";
                query += $" FROM DUAL";
                query += $" WHERE NOT EXISTS (";
                query += $" SELECT c.ID FROM tb_cartao c WHERE c.ID_PERSON = {idPerson} AND c.ATIVO = 1";
                query += $");";
            }

            var resultado = _repository.BuscaIdCartaoPorIdPerson(query);

            return resultado;
        }

        // Method responsible for returning one book by ID
        public CartaoVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible to crete one new book
        public CartaoVO Create(CartaoVO cartao)
        {
            var cartaoEntity = _converter.Parse(cartao);
            cartaoEntity = _repository.Create(cartaoEntity);
            return _converter.Parse(cartaoEntity);
        }

        // Method responsible for updating one book
        public CartaoVO Update(CartaoVO cartao)
        {
            var cartaoEntity = _converter.Parse(cartao);
            cartaoEntity = _repository.Update(cartaoEntity);
            return _converter.Parse(cartaoEntity);
        }

        // Method responsible for deleting a book from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
