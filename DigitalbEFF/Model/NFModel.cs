using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class NFModel
    {
        public int Id { get; set; }

        public int NF { get; set; }

        public int Id_Balanca { get; set; }

        public int Qt_Balanca { get; set; }

        public DateTime DataNF { get; set; }

        public double ValorNF { get; set; }

        public double Total { get; set; }
    }
}