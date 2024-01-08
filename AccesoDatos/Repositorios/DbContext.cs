using AccesoDatos.Entidades;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        // Método para leer todos los registros 
        public async Task<List<Usuario>> GetAllUsuarios()
        {
            await _connection.OpenAsync();

            try
            {
                var listaUsuarios = await _connection.QueryAsync<Usuario>("SELECT * FROM dbo.usuarios;");

                return listaUsuarios.ToList();
            }
            finally
            {
                _connection.Close();
            }
        }



        // Metodo para traer por id
        public async Task<Usuario> TraerPorId(int id)
        {

            await _connection.OpenAsync();

            try
            {
                var traer_por_id = await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM dbo.usuarios WHERE Id = @Id;", new { Id = id });

                return traer_por_id;


            }
            finally
            {
                _connection.Close();
            }

        }



        //Metodo para actualizar un campo


        public async Task<Usuario> ActualizzarCampo(int id, string nombre_usuario)
        {
            

            await _connection.OpenAsync();

            try
            {
                var actualizar_campo = await _connection.QueryFirstOrDefaultAsync<Usuario>("UPDATE dbo.usuarios SET nombre_usuario =  @Nuevonombre WHERE  ID=@Id",
                    new {NuevoNombre =nombre_usuario , Id = id});




                return actualizar_campo;


            }
            finally
            {
                _connection.Close();
            }

        }

    }

}     