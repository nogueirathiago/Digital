using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DigitalbEFF.Model
{
    public class BalancaModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Modelo { get; set; }

        [MaxLength(5)]
        public int Total { get; set; }

        [MaxLength(5)]
        public int Alugadas { get; set; }

        [MaxLength(5)]
        public int Disponíveis { get; set; }

    }
}