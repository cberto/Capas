using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class CondicionesIVA
    {
        public string CodigoIva { get; set; }
        public string DescripcionIva { get; set; }

        public CondicionesIVA()
        {
            CodigoIva = "";
            DescripcionIva = "";
        }
    }
}
