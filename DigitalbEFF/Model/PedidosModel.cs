using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalbEFF.Model;

namespace DigitalbEFF.Model
{
    public class PedidosModel
    {


        [Key]
        public int Id { get; set; }

        public int ID_Nf { get; set; }

        public int ID_Empresa { get; set; }

        [NotMapped]
        public string NomeEmpresa { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime? DataRetorno { get; set; }

        [MaxLength(1)]
        public string Situacao { get; set; }
    }
}