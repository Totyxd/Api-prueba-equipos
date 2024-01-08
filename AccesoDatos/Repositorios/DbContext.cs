using AccesoDatos.Entidades;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        public readonly SqlConnection _connection;


        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("sqlServerConnection"));

        }

        public async Task<List<Usuario>> Obtenertodo()
        {
            var result = await _connection.QueryAsync<Usuario>($"SELECT *  FROM dbo.Usuario");

            return result.ToList();

        }

        public async Task<List<Usuario>> ObtenerId(int id)
        {
            var resultado = await _connection.QueryAsync<Usuario>($"SELECT id FROM dbo.Usuario WHERE Id = @Id", new { Id = id });
            return resultado.ToList();
        }
        public async Task<int>  ActualizarEdad(int id, int NuevaEdad)
        {
            var actualizacion = await _connection.ExecuteAsync($"UPDATE dbo.usuario SET edad = @NuevaEdad WHERE id = @id;", new { Id = id, NuevaEdad = NuevaEdad });
            return actualizacion;
        }
    }
}
