using Microsoft.VisualBasic;
using RestWithASPNETUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace RestWithASPNETUdemy.Model
{
    [Table("tb_cartao")]
    public class Cartao : BaseEntity
    {

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }

        [Column("VALIDADE")]
        public string Validade { get; set; }

        [Column("NUMERO")]
        public string Numero { get; set; }

        [Column("BANDEIRA")]
        public string Bandeira { get; set; }

        [Column("CREDITO")]
        public bool Credito { get; set; }

        [Column("ID_PERSON")]
        public string IdPerson { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [Column("CVV")]
        public string Cvv { get; set; }

    }
}
