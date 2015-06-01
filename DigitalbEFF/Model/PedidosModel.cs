using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class PedidosModel
    {
        public int Id { get; set; }

        public int Cd_Pedido { get; set; }

        public int NF { get; set; }

        public int Id_Empresa { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataRetorno { get; set; }

        public char Situacao { get; set; }
    }
}