using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RestWithASPNETUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace RestWithASPNETUdemy.Model
{
    [Table("person")]
    public class Person : BaseEntity 
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("enabled")]
        public bool Enabled { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("dt_nascimento")]
        public string DataNascimetno { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("celular")]
        public string Celular { get; set; }
        
        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("uf")]
        public string Uf { get; set;}

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("rua")]
        public string Rua { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [NotMapped]
        public string IdCartao { get; set; }

    }
}
