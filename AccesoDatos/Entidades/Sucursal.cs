using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Sucursal
    {
        public int id { get; set; }
        public string nombre { get; set; }

    }
    public class Usuario
    {
       
        public int Id { get; set; }
        public string? Nombre_de_usuario { get; set; }

        public string? Contraseña { get; set; }

        public int Edad { get; set; }

        public bool Sexo { get; set; }

    }
}

