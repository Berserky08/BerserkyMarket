using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Barrio
    {
        public int IdBarrio { get; set; }
        public string Descripcion { get; set; }
        public Ciudad oCiudad { get; set; }
        public Departamento oDepartameto { get; set; }
    }
}
