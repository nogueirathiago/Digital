using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalbEFF.Model
{
    public class NFModel
    {
        [Key]
        public int Id { get; set; }

        public int? NF { get; set; }

        public int ID_Balancas { get; set; }

        [NotMapped]
        public string NomeBalanca { get; set; }

        public int Qt_Balanca { get; set; }

        public DateTime DataNF { get; set; }

        public decimal ValorNF { get; set; }

        public decimal Total { get; set; }

    }
}