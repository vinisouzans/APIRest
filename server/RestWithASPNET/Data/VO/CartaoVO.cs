using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class CartaoVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string Numero { get; set; }

        public string Validade { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Bandeira { get; set; }

        public bool Credito { get; set; }

        public string IdPerson { get; set; }

        public bool Ativo { get; set; }

        public string Cvv { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
