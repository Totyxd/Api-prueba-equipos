using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public abstract class RepositorioDapperMaestro
    {
        protected DbContext _context;

        protected async Task<int> ExecuteNonQueryAsync<T>(string TxtSql, T objeto)
        {

            try
            {
                var resp = await _context._connection.ExecuteAsync(TxtSql, objeto);
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw;
            }


        }
        protected async Task<int> ExecuteNonQueryAsyncParams<T>(string TxtSql, DynamicParameters parametros)
        {

            try
            {
                var resp = await _context._connection.ExecuteAsync(TxtSql, parametros);
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw;
            }


        }
        protected async Task<T> ExecuteReaderStringAsync<T>(String TxtSql, string parametro)
        {

            try
            {
                var result = await _context._connection.QuerySingleOrDefaultAsync<T>(TxtSql, new { Parametro = parametro });
                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw;
            }

        }



        protected async Task<T> ExecuteReaderIdAsync<T>(String TxtSql, int id)
        {

            try
            {
                var result = await _context._connection.QuerySingleOrDefaultAsync<T>(TxtSql, new { id });
                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                throw;
            }

        }
        protected async Task<int> ExecuteStoredProcedure(string procedureName)
        {
            try
            {
                var insert = await _context._connection.ExecuteScalarAsync<int>(procedureName);
                return insert;
            }
            catch (Exception e)
            {
                var excep = new Exception("No se pudo crear registro.");
                excep.Data.Add("name", "ErrorCreacionRegistro");
                excep.Data.Add("status", "400");
                throw excep;
            }
        }

        protected async Task<T> QueryStoredProcedure<T>(string procedureName, DynamicParameters parametros = null)
        {
            try
            {
                return await _context._connection.ExecuteScalarAsync<T>(procedureName, parametros, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                var excep = new Exception("No se pudo crear registro.");
                excep.Data.Add("name", "ErrorCreacionRegistro");
                excep.Data.Add("status", "400");
                throw excep;
            }
        }

        protected async Task<List<T>> ExecuteReaderAsync<T>(String TxtSql, DynamicParameters parametros = null)
        {
            var resultado = new List<T>();
            try
            {
                var result = await _context._connection.QueryAsync<T>(TxtSql, parametros);
                resultado = result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return resultado;

        }

        protected async Task<T> ExecuteSingleReaderAsync<T>(String TxtSql, Object parametros = null)
        {
            var result = await _context._connection.QuerySingleAsync<T>(TxtSql, parametros);
            return result;
        }

    }
}
