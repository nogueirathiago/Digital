using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalbEFF.Model
{
    public class PedidosModel
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cd_Pedido { get; set; }
        
        public int ID_Nf { get; set; }

        public int ID_Empresa { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime? DataRetorno { get; set; }

        public char Situacao { get; set; }
    }
}