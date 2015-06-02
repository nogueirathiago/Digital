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

        
        public int Total { get; set; }

        
        public int Alugadas { get; set; }

        
        public int Disponíveis { get; set; }

    }
}