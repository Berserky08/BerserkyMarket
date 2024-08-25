using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Descripcion { get; set; }
        public Departamento oDepartamento { get; set; }
    }
}
