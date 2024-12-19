using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.VO
{
    public class CarVO : ISupportsHyperMedia
    {
        public long Id { get; set; }

        public string Modelo { get; set; }

        public string Fabricante { get; set; }

        public decimal Preco { get; set; }

        public DateTime FabDate { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
