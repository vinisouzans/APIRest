using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public bool Enabled { get; set; }

        public string Cpf { get; set; }

        public string DataNascimento { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string IdCartao { get; set; }


        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
