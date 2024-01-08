using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre_usuario { get; set; }

        public string email { get; set; }

        public string contrasena { get; set; }

        public string rol { get; set; }

        public int edad { get; set; }

        public int sexo { get; set; }

        public int id_sucursales {get; set; }



   

}
}
