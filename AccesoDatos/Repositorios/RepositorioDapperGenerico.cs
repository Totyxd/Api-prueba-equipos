using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Contratos;

namespace AccesoDatos.Repositorios
{
    public abstract class RepositorioDapperGenerico<TEntity> : RepositorioDapperMaestro, IRepositorioGenerico<TEntity> where TEntity : class
    {
        protected string _insert;
        protected string _update;
        protected string _delete;
        protected string _selectAll;
        protected string _selectId;


        public Task<int> AgregarAsync(TEntity entity)
        {

            return ExecuteNonQueryAsync(_insert, entity);
        }


        public Task<int> EditarAsync(TEntity entity)
        {

            return ExecuteNonQueryAsync(_update, entity);
        }


        public Task<int> EliminarAsync(int idPK)
        {
            var resp = ExecuteNonQueryAsync(_delete, new { id = idPK });
            return resp;
        }

        public async Task<TEntity> TraerIdAsync(int id)
        {

            return await ExecuteReaderIdAsync<TEntity>(_selectId, id);
        }

        public async Task<List<TEntity>> TraerTodosAsync()
        {
            return await ExecuteReaderAsync<TEntity>(_selectAll);
        }
    }
}
