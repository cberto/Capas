using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using Common;

namespace CapaNegocio
{
    public class NEGCondicionesIva
    {
        private readonly DatosCondicionesIva dp = new DatosCondicionesIva();

        public IList<CondicionesIVA> Buscar()
        {
            return dp.Buscar();
        }
    }
}
