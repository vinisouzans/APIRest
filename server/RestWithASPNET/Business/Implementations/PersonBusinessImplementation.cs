using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        // Method responsible for returning all people,
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from person p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and p.first_name like '%{name}%' ";
            query += $" order by p.first_name {sort} limit {size} offset {offset}";
            
            string countQuery = @"select count(*) from person p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and p.first_name like '%{name}%' ";

            var persons = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> { 
                CurrentPage = page,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        // Method responsible for returning one person by ID
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        // Method responsible to crete one new person
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for updating one person
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            
            PersonVO personNaBase = FindByID(person.Id);

            if (string.IsNullOrEmpty(personEntity.FirstName)) {
                personEntity.FirstName = personNaBase.FirstName;
            }

            if (string.IsNullOrEmpty(personEntity.LastName)) {
                personEntity.LastName = personNaBase.LastName;
            }

            if (string.IsNullOrEmpty(personEntity.Gender)) {
                personEntity.Gender = personNaBase.Gender;
            }

            personEntity.Enabled = true;

            if (string.IsNullOrEmpty(personEntity.Cpf)) {
                personEntity.Cpf = personNaBase.Cpf;
            }

            if (string.IsNullOrEmpty(personEntity.DataNascimetno)) {
                personEntity.DataNascimetno = personNaBase.DataNascimento;
            }

            if (string.IsNullOrEmpty(personEntity.Email)) {
                personEntity.Email = personNaBase.Email;
            }

            if (string.IsNullOrEmpty(personEntity.Celular)) {
                personEntity.Celular = personNaBase.Celular;
            }

            if (string.IsNullOrEmpty(personEntity.Cidade)) 
            {
                personEntity.Cidade = personNaBase.Cidade;
            }

            if (string.IsNullOrEmpty(personEntity.Uf)) {
                personEntity.Uf = personNaBase.Uf;
            }

            if (string.IsNullOrEmpty(personEntity.Complemento)) {
                personEntity.Complemento = personNaBase.Complemento;
            }

            if (string.IsNullOrEmpty(personEntity.Bairro)) {
                personEntity.Bairro = personNaBase.Bairro;
            }

            if (string.IsNullOrEmpty(personEntity.Rua)) {
                personEntity.Rua = personNaBase.Rua;
            }

            if (string.IsNullOrEmpty(personEntity.Numero)) {
                personEntity.Numero = personNaBase.Numero;
            }

            if (string.IsNullOrEmpty(personEntity.Cep)) {
                personEntity.Cep = personNaBase.Cep;
            }

            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        // Method responsible for disable a person from an ID
        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
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
    }
}
