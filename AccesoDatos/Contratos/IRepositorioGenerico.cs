using static Dapper.SqlMapper;

namespace AccesoDatos.Contratos
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task<TEntity> TraerIdAsync(int id);
        Task<int> AgregarAsync(TEntity entity);
        Task<int> EditarAsync(TEntity entity);
        Task<int> EliminarAsync(int id);
        Task<List<TEntity>> TraerTodosAsync();
    }
}