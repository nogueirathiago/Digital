using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalbEFF.Model
{
    public class PedidosModel
    {
        public int Id { get; set; }

        public int Cd_Pedido { get; set; }
        
        public virtual NFModel NF { get; set; }

        public virtual EmpresaModel Empresa { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataRetorno { get; set; }

        public char Situacao { get; set; }
    }
}