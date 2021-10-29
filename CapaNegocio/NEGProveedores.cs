using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using Common;

namespace CapaNegocio
{
    public class NEGProveedores
    {
        private readonly DatosProveedores dp = new DatosProveedores();

        public IList<Proveedor> Buscar()
        {
            return dp.Buscar();
        }

        //Me trae una Proveedor si tiene ID
        public Proveedor Buscar(int id)
        {
            return dp.Buscar(id);
        }

        //Me trae una Proveedor si tiene ID
        public string Borrar(int id)
        {
            return dp.Borrar(id);
        }

        public bool Crear(Proveedor p)
        {
            return dp.Crear(p);
        }
    }
}
