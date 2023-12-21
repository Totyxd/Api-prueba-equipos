using AccesoDatos.Entidades;
using AccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios.Prueba
{
    public class RepositorioSucursales : RepositorioDapperGenerico<Sucursal>
    {
        public RepositorioSucursales(DbContext context)
        {
            _context = context;
            _selectAll = "SELECT * FROM dbo.Sucursales;";
            _selectId = "SELECT * FROM dbo.Sucursales WHERE id=@id;";
            _insert = "INSERT INTO dbo.Sucursales (nombre) VALUES (@nombre);";
        }
    }
}
