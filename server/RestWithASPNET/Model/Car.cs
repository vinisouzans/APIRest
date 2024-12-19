using RestWithASPNETUdemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace RestWithASPNETUdemy.Model
{
    [Table("cars")]
    public class Car : BaseEntity
    {
           
        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("fabricante")]
        public string Fabricante { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }

        [Column("fab_data")]
        public DateTime FabDate { get; set; }
        
    }
}
